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
    private void Start()
    {
        _soundDamageEffectController = GetComponent<SoundDamageEffectController>();
        _shrek = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Target != null)
        {
            _shrek.SetDestination(Target.position);
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
}