using System.Collections.Generic;

using UnityEngine;

namespace Sounds
{
    public class SoundDamageEffectController : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> _damages;
        private int _index;
        public AudioSource AudioSource => _audioSource;
        private AudioSource _audioSource;
    
        // Start is called before the first frame update
        void Start()
        {
            _index = 0;
            _audioSource = GetComponent<AudioSource>();
        }
    
        public void OnDamage()
        {
            _audioSource.PlayOneShot(_damages[_index]);
            _index = (_index + 1) % _damages.Count;
        }
    }
}