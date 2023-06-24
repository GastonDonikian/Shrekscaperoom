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
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private List<int> _layerMask;
    [SerializeField] private Camera _camera;
    
    public AudioSource AudioSource => _audioSource;
    private AudioSource _audioSource;
    
    [SerializeField] private List<AudioClip> _misses;
    
    [SerializeField] private AudioClip _reload;
    [SerializeField] private AudioClip _shoot;
    [SerializeField] private AudioClip _hit;
    private int _index;
    
    public override bool Attack()
    {
        if (base.Attack() == true)
        {
            _animator.SetTrigger("Shoot");
            _muzzleFlash.Play();
            _audioSource.PlayOneShot(_shoot);
            Shoot();
            return true;
        }
        return false;
    }

    public override bool Reload()
    {
        
        if (base.Reload() == true)
        {
            _audioSource.PlayOneShot(_reload);
            _animator.SetTrigger("Reload");
            return true;
        }

        return false;
    } 
    

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _index = 0;
        _audioSource = GetComponent<AudioSource>();
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
                _audioSource.PlayOneShot(_hit);
                GameObject explosion = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(transform.forward));
                Destroy(explosion, 0.2f);
            }
            else
            {
                _audioSource.PlayOneShot(_misses[_index]);
                _index = (_index + 1) % _misses.Count;
                GameObject explosion = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(explosion, 0.2f);
            }
        }
    }
}
