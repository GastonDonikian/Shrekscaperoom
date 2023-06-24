using System;
using System.Collections;
using System.Collections.Generic;
using Sounds;
using UnityEngine;
using UnityEngine.AI;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GlobalScripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Shrek : Actor
{
    private NavMeshAgent _shrek;
    public Transform Target;
    private MovementController _movementController;
    private SoundDamageEffectController _soundDamageEffectController;
    [SerializeField] private Image _screamerImage;
    private bool doorDestroyed = false;
    private Animator _animator;
    private void Start()
    {
        _screamerImage.enabled = false;
        _screamerImage.GetComponent<AudioSource>().enabled = false;
        _soundDamageEffectController = GetComponent<SoundDamageEffectController>();
        _shrek = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        EventManager.instance.OnChase += OnChase;
    }

    void Update()
    {
        if (Target != null && doorDestroyed)
        {
            _shrek.SetDestination(Target.position);
            _animator.SetBool("isMoving", _shrek.velocity.magnitude > 0.1f);
        }
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        //if collided with character give character damage
        if (collision.gameObject.layer == 6)
        {
            _screamerImage.enabled = true;
            _screamerImage.GetComponent<AudioSource>().enabled = true;
            _screamerImage.GetComponent<AudioSource>().Play();
            _soundDamageEffectController.OnDamage();
            var damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null)
            {
                EventQueueManager.instance.AddEvent(new CmdApplyDamage(damageable, 10000));
            }
            
        }
    }
    
    private void OnChase(bool isBroken)
    {
        doorDestroyed = isBroken;
        _animator.SetTrigger("release");
        _animator.SetBool("isMoving", true);
    }
}
