using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectController : MonoBehaviour
{
    [SerializeField] private AudioClip _victory;
    [SerializeField] private AudioClip _defeat;
    
    public AudioSource AudioSource => _audioSource;
    private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        EventManager.instance.OnGameOver += OnGameOver;
    }
    
    private void OnGameOver(bool isVictory, string cause)
    {
        _audioSource.PlayOneShot(isVictory ? _victory : _defeat);
    }
}
