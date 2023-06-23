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
    public float ReloadCooldown => _gunStats.ReloadCooldown;
    public float Range => _gunStats.Range;



    protected float currentShootCooldown = 0f;
    protected float currentReloadCooldown = 0f;

    public virtual bool Attack()
    {
        if (HasBullets && currentShootCooldown <= 0 && currentReloadCooldown <= 0)
        {
            currentShootCooldown = ShotCooldown;
            currentBulletCount--;
            return true;
        }

        return false;
    }


    public virtual bool Reload()
    {
        if (currentReloadCooldown <= 0 && currentShootCooldown <= 0)
        {
            currentBulletCount = MagSize;
            currentReloadCooldown = ReloadCooldown;
            return true;
        }

        return false;
    }

    private void Update()
    {
        if (currentShootCooldown >= 0)
        {
            currentShootCooldown -= Time.deltaTime;
        }

        if (currentReloadCooldown >= 0) 
        {
            currentReloadCooldown -= Time.deltaTime;
        }
    }
    
    protected bool HasBullets => currentBulletCount > 0;
}
