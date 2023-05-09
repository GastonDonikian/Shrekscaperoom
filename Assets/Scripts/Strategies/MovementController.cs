using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour, IMovable, IRotable
{

    public float MovementSpeed => GetComponent<Actor>().ActorStats.MovementSpeed;

    public void Move(Vector3 direction)
    { 
        transform.position += direction * (MovementSpeed * Time.deltaTime);
    }

    public float RotationSpeed => GetComponent<Actor>().ActorStats.RotationSpeed;

    public void Rotate(Vector3 direction)
    {
        transform.rotation *= Quaternion.Euler(direction * (RotationSpeed * Time.deltaTime));
    }
}
