using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machingun : Gun
{
   [SerializeField] private float _bulletCountPerShot = 5;
   public override void Attack()
   {
      if (HasBullets && currentShootCooldown <= 0)
      {
         for (int i = 0; i < _bulletCountPerShot; i++)
         {
            Instantiate(
               BulletPrefab, transform.position + Vector3.forward * i * 0.6f, transform.rotation);
            currentBulletCount--;
         }
      }
   }
}
