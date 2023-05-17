using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IMovable
{
   float MovementSpeed { get; }
   void Move(Vector3 direction);

   void ReduceSpeed(int speed);

   void IncreaseSpeed(int speed);
}
