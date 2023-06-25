using System.Collections;
using System.Collections.Generic;
using Commands;
using Sounds;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Donkey : Actor
{
    private NavMeshAgent _donkey;
    private Transform _target;
    [SerializeField] private GameObject _explosionFxPrefab;

    private MovementController _movementController;
    private SoundDamageEffectController _soundDamageEffectController;
    private bool collided = false;
    private Animator _animator;
    private void Start()
    {
        _target = GameObject.Find("Character").transform;
        _soundDamageEffectController = GetComponent<SoundDamageEffectController>();
        _donkey = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        
    }
    
    void Update()
    {
        if (_target != null && !collided)
        {
            _donkey.SetDestination(_target.position);
        }
        _animator.SetBool("isMoving", _donkey.velocity.magnitude > 0.1f);
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        
        //if collided with character give character damage
        if (collision.gameObject.layer == 6 && !collided)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            _donkey.enabled = false;
            _soundDamageEffectController.OnDamage();
            var movable = collision.gameObject.GetComponent<IMovable>();
            if (movable != null) EventQueueManager.instance.AddEvent(new CmdReduceSpeed(movable, 1));
            Explosion();
            collided = true;
            Destroy(this.gameObject,0.5f);
        }
    }
    
    private void Explosion()
    {
        //instancia visual effect
        Instantiate(_explosionFxPrefab, transform.position, transform.rotation, transform);
        //encontrar objetos cercanos
        this.enabled = false;
        Debug.Log("BOOOOM!");
        Invoke("DestroyDonkey", 0.5f);
    }
    private void DestroyDonkey() => Destroy(this.GameObject());
}

