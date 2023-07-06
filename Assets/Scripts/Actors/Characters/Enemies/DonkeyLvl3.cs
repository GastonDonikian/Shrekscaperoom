using System.Collections;
using System.Collections.Generic;
using Commands;
using Sounds;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class DonkeyLvl3 : Actor
{
    private NavMeshAgent _donkey;
    private Transform _target;

    private MovementController _movementController;
    private Animator _animator;
    private void Start()
    {
        _target = GameObject.Find("DonkeyTarget").transform;
        _donkey = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        
    }
    
    void Update()
    {
        if (_target != null)
        {
            _donkey.SetDestination(_target.position);
        }
        _animator.SetBool("isMoving", _donkey.velocity.magnitude > 0.1f);
    }
}

