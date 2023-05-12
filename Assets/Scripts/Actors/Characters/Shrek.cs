using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shrek : Actor
{
    [SerializeField] private Transform target;
    private Rigidbody rb;

    private MovementController _movementController;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _movementController = GetComponent<MovementController>();
    }

    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        rb.MoveRotation(lookRotation);
        EventQueueManager.instance.AddEvent(new CmdMovement(_movementController, direction));
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        //if collided with character give character damage
        if (collision.gameObject.layer == 6)
        {
            var damageable = collision.gameObject.GetComponent<IDamageable>();
            if (damageable != null) EventQueueManager.instance.AddEvent(new CmdApplyDamage(damageable, 10000));
        }
    }
}
