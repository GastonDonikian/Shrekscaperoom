using System;
using UnityEngine;

namespace Sounds
{
    public class BackgroundMusicController : MonoBehaviour, ISoundPlayable
    {
        public AudioClip AudioClip => _audioClip;
        [SerializeField] private AudioClip  _audioClip;

        public AudioSource AudioSource => _audioSource;
        [SerializeField] private AudioSource _audioSource;

        public float Volume => _volume;
        [Range(0f, 1f)]
        [SerializeField] private float _volume = 1;
    
        public bool Mute => _mute;
        [SerializeField] private bool _mute = false;

        public void SetAudioClip(AudioClip audioClip)
        {
            _audioClip = audioClip;
        }
        public void InitAudio()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.volume = _volume;
            _audioSource.mute = _mute;
            _audioSource.clip = _audioClip;
        }
    
        public void Play() => _audioSource.Play();
        
        public void Start()
        {
            InitAudio();
            Play();
        }

        public void Pause()
        {
            throw new System.NotImplementedException();
        }

        public void Stop()
        {
            throw new System.NotImplementedException();
        }

        public void PlayOnShot()
        {
            throw new System.NotImplementedException();
        }
    }
}