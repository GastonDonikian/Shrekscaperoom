using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using GlobalScripts;

public class Pistol : Gun
{
    private Animator _animator;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private List<int> _layerMask;
    [SerializeField] private Camera _camera;
    public override bool Attack()
    {
        if (base.Attack() == true)
        {
            _animator.SetTrigger("Shoot");
            _muzzleFlash.Play();
            Shoot();
            return true;
        }
        return false;
    }

    public override bool Reload()
    {
        
        if (base.Reload() == true)
        {
            _animator.SetTrigger("Reload");
            return true;
        }

        return false;
    } 
    

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, Range))
        {
            Debug.Log(hit.transform.gameObject.name);
            if (_layerMask.Contains(hit.transform.gameObject.layer))
            {
                IDamageable damageable = hit.transform.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    EventQueueManager.instance.AddEvent(new CmdApplyDamage(damageable, Damage + GlobalUpgrades.instance.power));
                }
            }
            GameObject explosion = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(explosion, 0.2f);
        }
    }
}
