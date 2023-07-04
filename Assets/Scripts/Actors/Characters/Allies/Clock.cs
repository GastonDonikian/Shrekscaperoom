using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Clock : Actor
{
    private void Update()
    {
        EventQueueManager.instance.AddEvent(new CmdRotation(GetComponent<IRotable>(), new Vector3(0, 2, 0)));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Characterlvl2")
        {
            EventQueueManager.instance.AddEvent(new CmdHeal(other.GetComponent<IDamageable>(), 20));
            Destroy(this.gameObject);
        }
    }
}
