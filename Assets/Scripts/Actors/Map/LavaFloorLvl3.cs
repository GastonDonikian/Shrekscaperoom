using System;
using System.Collections;
using System.Collections.Generic;
using Sounds;
using UnityEngine;

public class LavaFloorLvl3 : MonoBehaviour
{
    
    private SoundDamageEffectController _soundDamageEffectController;
    public void OnCollisionEnter(Collision collision)
    {
        //if collided with character give character damage
        if (collision.gameObject.layer == 6)
        {
            Debug.Log("LAVA");
            _soundDamageEffectController.OnDamage();
        }
        var damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null) EventQueueManager.instance.AddEvent(new CmdApplyDamage(damageable, 10000));
    }
    private void Start()
    {
        _soundDamageEffectController = GetComponent<SoundDamageEffectController>();
    }
}
