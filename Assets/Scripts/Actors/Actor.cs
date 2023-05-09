using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public ActorStats ActorStats => _actorStats;
    [SerializeField] protected ActorStats _actorStats;
    
    protected LifeController _lifeController;
    

    private void Start()
    {
        _lifeController = GetComponent<LifeController>();
    }
}
