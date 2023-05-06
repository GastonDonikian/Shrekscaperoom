using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRotable
{
    float RotationSpeed { get; }
    void Rotate(Vector3 direction);
}
