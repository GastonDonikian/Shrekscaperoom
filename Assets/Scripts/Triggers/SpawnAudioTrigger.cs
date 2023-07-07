using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnAudioTrigger : MonoBehaviour
{
    private AudioSource _audioSource;
    private bool _notPlayed ;
    private void Start()
    {
        _notPlayed = true;
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_notPlayed)
        {
            _notPlayed = false;
            _audioSource.PlayOneShot(_audioSource.clip);
        }

    }

}