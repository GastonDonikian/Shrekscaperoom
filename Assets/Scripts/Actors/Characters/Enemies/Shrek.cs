using System;
using System.Collections;
using System.Collections.Generic;
using Sounds;
using UnityEngine;
using UnityEngine.AI;

public class Shrek : Actor
{
    private NavMeshAgent _shrek;
    public Transform Target;

    private MovementController _movementController;
    private SoundDamageEffectController _soundDamageEffectController;
    private bool doorDestroyed = false;
    private Animator _animator;
    private void Start()
    {
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
            _soundDamageEffectController.OnDamage();
            var damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null) EventQueueManager.instance.AddEvent(new CmdApplyDamage(damageable, 10000));
            
        }
    }
    
    private void OnChase(bool isBroken)
    {
        doorDestroyed = isBroken;
        _animator.SetTrigger("release");
        _animator.SetBool("isMoving", true);
    }
}
