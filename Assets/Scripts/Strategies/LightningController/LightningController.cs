using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LightningController : MonoBehaviour
{
    public AudioSource AudioSource => _audioSource;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _lightningClip;
    private bool lightningCalled = true;
    private void Start()
    {
        RenderSettings.ambientIntensity = 0f;
        _audioSource = GetComponent<AudioSource>();
        
        float rand = Random.Range(3.5f, 7.5f);
        Invoke("SetCalled", rand); 
    }

    void CallLightning()
    {
        int r = Random.Range(0, 3);
        RenderSettings.ambientIntensity = 4f;
        Invoke("TurnOffLightning", .75f + .25f * r);
        Invoke("CallThunder",r *.2f );
        float rand = Random.Range(3.5f, 7.5f);
        Invoke("SetCalled", rand); 
    }
    void TurnOffLightning()
    {
        RenderSettings.ambientIntensity = 0f;
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
