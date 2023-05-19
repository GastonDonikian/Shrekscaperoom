using System;
using System.Collections;
using System.Collections.Generic;
using GlobalScripts;
using UnityEngine;

public class Gun : MonoBehaviour, IGun
{

    [SerializeField] protected GunStats _gunStats;
    public GameObject BulletPrefab => _gunStats.BulletPrefab;

    public int Damage => _gunStats.Damage;

    public int MagSize => _gunStats.MaxBulletCount;

    public int CurrentBulletCount => currentBulletCount;
    [SerializeField] protected int currentBulletCount = 0;
    
    public float ShotCooldown => _gunStats.ShotCooldown;
    
    
    protected float currentShootCooldown = 0f;

    public virtual void Attack()
    {
        if (HasBullets && currentShootCooldown <= 0)
        {
            GameObject bullet = Instantiate(BulletPrefab, transform.position + Vector3.forward * 0.2f, transform.rotation);
            bullet.GetComponent<Bullet>().Damage = Damage + GlobalUpgrades.instance.power;
            
            currentShootCooldown = ShotCooldown;
            currentBulletCount--;
        }
    }
    

    public virtual void Reload() => currentBulletCount = MagSize;

    private void Update()
    {
        if (currentShootCooldown >= 0)
        {
            currentShootCooldown -= Time.deltaTime;
        }
    }
    
    protected bool HasBullets => currentBulletCount > 0;
}
