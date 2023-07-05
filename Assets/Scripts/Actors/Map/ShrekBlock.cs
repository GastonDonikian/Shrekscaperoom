using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrekBlock : MonoBehaviour
{
    private Transform _target;
    void Update()
    {
        Vector3 direction = _target.position - transform.position;
        direction.y = 1;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void Start()
    {
        _target = GameObject.Find("CharacterLvl3").transform;
    }
}
