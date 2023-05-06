using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour, IMovable, IRotable
{
    public float MovementSpeed => _movementSpeed;
    private float _movementSpeed = 10f;
    public float RotationSpeed => _rotationSpeed;
    private float _rotationSpeed = 50f;
    
    public void Move(Vector3 direction)
    { 
        transform.position += direction * (MovementSpeed * Time.deltaTime);
    }
    
    public void Rotate(Vector3 direction)
    {
        transform.rotation *= Quaternion.Euler(direction * (RotationSpeed * Time.deltaTime));
    }
}
