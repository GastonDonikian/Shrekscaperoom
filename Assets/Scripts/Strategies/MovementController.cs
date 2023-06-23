using System;
using System.Collections;
using System.Collections.Generic;
using GlobalScripts;
using UnityEngine;

public class MovementController : MonoBehaviour, IMovable, IRotable
{

    public float MovementSpeed => GetComponent<Actor>().ActorStats.MovementSpeed;

    
    public float CurrentSpeed => _currentSpeed;
    [SerializeField] private float _currentSpeed;
    
    

    public void Move(Vector3 direction)
    { 
        transform.position += direction * (MovementSpeed * Time.deltaTime);
    }

    public void ReduceSpeed(int speed)
    {
        if (_currentSpeed > 1)
        {
            _currentSpeed -= speed;
        }
    }

    public void IncreaseSpeed(int speed)
    {
        _currentSpeed += speed;
    }

    public float RotationSpeed => GetComponent<Actor>().ActorStats.RotationSpeed;

    public void Rotate(Vector3 direction)
    {
        transform.rotation *= Quaternion.Euler(direction * (RotationSpeed * Time.deltaTime));
    }

    private void Start()
    {
        _currentSpeed = MovementSpeed + GlobalUpgrades.instance.speed;
    }
}
