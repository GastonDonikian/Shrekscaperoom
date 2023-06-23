using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pistol : Gun
{
    public override bool Attack()
    {
        
        if (base.Attack() == true)
        {
            _animator.SetTrigger("Shoot");
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
    
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }
}
