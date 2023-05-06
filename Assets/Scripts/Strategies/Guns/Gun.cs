using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IGun
{
    public GameObject BulletPrefab => _bulletPrefab;
    [SerializeField] private GameObject _bulletPrefab;
    
    public int Damage => _damage;
    [SerializeField] private int _damage = 10;
    
    public int MagSize => _magSize;
    [SerializeField] private int _magSize = 20;
    
    public int CurrentBulletCount => currentBulletCount;
    [SerializeField] protected int currentBulletCount = 0;
    
    public float ShotCooldown => _shootCooldown;
    
    [SerializeField] private float _shootCooldown = .5f;
    protected float currentShootCooldown = 0f;

    public virtual void Attack()
    {
        if (HasBullets && currentShootCooldown <= 0)
        {
            Instantiate(_bulletPrefab, transform.position + Vector3.forward * 1, transform.rotation);
            currentShootCooldown = _shootCooldown;
            currentBulletCount--;
        }
    }
    

    public virtual void Reload() => currentBulletCount = _magSize;

    private void Update()
    {
        if (currentShootCooldown >= 0)
        {
            currentShootCooldown -= Time.deltaTime;
        }
    }
    
    protected bool HasBullets => currentBulletCount > 0;
}
