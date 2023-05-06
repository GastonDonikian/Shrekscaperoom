using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DorbellController : MonoBehaviour, ISoundPlayable
{
    public AudioClip AudioClip => _audioClip;
    [SerializeField] private AudioClip  _audioClip;

    public AudioSource AudioSource => _audioSource;
    private AudioSource _audioSource;

    public float Volume => _volume;
    [Range(0f, 1f)]
    [SerializeField] private float _volume = 1;
    
    public bool Mute => _mute;
    [SerializeField] private bool _mute = false;
    
    public void InitAudio()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _volume;
        _audioSource.mute = _mute;
        _audioSource.clip = _audioClip;
    }
    
    public void Play() => _audioSource.Play();
    

    public void Pause() => _audioSource.Pause();
   

    public void Stop() => _audioSource.Stop();
    

    public void PlayOnShot() => _audioSource.PlayOneShot(_audioClip);

        void Start() => InitAudio();

        // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) PlayOnShot();
        if (Input.GetKeyDown(KeyCode.P)) Play();;
        if (Input.GetKeyDown(KeyCode.Space)) Pause();
        if (Input.GetKeyDown(KeyCode.S)) Stop();
    }
}
