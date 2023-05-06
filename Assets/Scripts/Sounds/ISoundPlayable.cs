using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISoundPlayable
{
    AudioClip AudioClip { get; }
    AudioSource AudioSource { get; }
    
    float Volume { get; }
    bool Mute { get; }

    void Play();
    void Pause();
    void Stop();

    void InitAudio();
    void PlayOnShot();
}
