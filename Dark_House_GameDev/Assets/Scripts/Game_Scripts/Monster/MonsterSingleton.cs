using Core;
using UnityEngine;

namespace Game_Scripts.Monster{
    public class MonsterSingleton: Singleton<MonsterSingleton>{
        [SerializeField] private AudioClip[] _audioClipsArray;
        private AudioSource _audioSource;
        
        private void Awake() {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayAnAudioFromAudioArray(int index) {
            _audioSource.clip = _audioClipsArray[index];
            _audioSource.Play();
        }

        public AudioClip[] AudioClipsArray => _audioClipsArray;

        public AudioSource AudioSource => _audioSource;
    }
}