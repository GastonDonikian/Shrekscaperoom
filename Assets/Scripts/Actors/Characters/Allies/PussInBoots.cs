using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class PussInBoots : Actor
{
    private NavMeshAgent _puss;
    [SerializeField] private Transform[] _wayPoints;
    private MovementController _movementController;
    //private Animator _animator;
    private int _waypointIndex = 0;
    void Start()
    {
        _puss = GetComponent<NavMeshAgent>();
        UpdateDestination();
        //_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _wayPoints[_waypointIndex].position) < 1)
        {
            Debug.Log("setWaypoint");
            IterateWaypointIndex();
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        Debug.Log(_wayPoints[_waypointIndex]);
        _puss.SetDestination(_wayPoints[_waypointIndex].position);
    }

    void IterateWaypointIndex()
    {
        int r = Random.Range(0, _wayPoints.Length);
        _waypointIndex = r;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.name == "Characterlvl2")
        {
            Debug.Log("Winlvl2");
        }
    }
}
