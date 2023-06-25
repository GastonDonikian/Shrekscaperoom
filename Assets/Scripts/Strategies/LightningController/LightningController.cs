using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LightningController : MonoBehaviour
{
    [SerializeField] private GameObject[] _lightnings;
    public AudioSource AudioSource => _audioSource;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _lightningClip;
    private bool lightningCalled = true;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        foreach (var lightning in _lightnings)
        {
            lightning.SetActive(false);
        }
        float rand = Random.Range(3.5f, 7.5f);
        Invoke("SetCalled", rand); 
    }

    void CallLightning()
    {
        int r = Random.Range(0, 3);
        _lightnings[r].SetActive(true);
        Invoke("TurnOffLightning", .75f + .25f * r);
        Invoke("CallThunder",r *.2f );
        float rand = Random.Range(3.5f, 7.5f);
        Invoke("SetCalled", rand); 
    }
    void TurnOffLightning()
    {
        foreach (var lightning in _lightnings)
        {
            lightning.SetActive(false);
        }
    }

    void CallThunder()
    {
        _audioSource.PlayOneShot(_lightningClip);
    }
    void SetCalled()
    {
        lightningCalled = false;
    }

    private void Update()
    {
        if (!lightningCalled)
        {
            lightningCalled = true;
            CallLightning();
        }
    }
}
