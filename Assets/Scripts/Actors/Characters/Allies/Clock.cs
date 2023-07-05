using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Clock : Actor
{
    public AudioSource AudioSource => _audioSource;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _grab;
    private void Update()
    {
        EventQueueManager.instance.AddEvent(new CmdRotation(GetComponent<IRotable>(), new Vector3(0, 2, 0)));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Characterlvl2")
        {
            EventQueueManager.instance.AddEvent(new CmdHeal(other.GetComponent<IDamageable>(), 20));
            GetComponent<Collider>().enabled = false;
            Renderer[] rs = GetComponentsInChildren<MeshRenderer>();
            foreach(Renderer r in rs)
                r.enabled = false;
            _audioSource.PlayOneShot(_grab);
            Invoke("End", 2f);
        }
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void End()
    {
        Destroy(this.gameObject);
    }
}
