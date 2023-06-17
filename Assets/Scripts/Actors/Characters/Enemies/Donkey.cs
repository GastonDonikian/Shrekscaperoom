using System.Collections;
using System.Collections.Generic;
using Commands;
using Sounds;
using UnityEngine;
using UnityEngine.AI;

public class Donkey : Actor
{
    private NavMeshAgent _donkey;
    private Transform _target;

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
            collided = true;
            Destroy(this.gameObject,0.5f);
        }
    }
}

