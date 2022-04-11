using Core;
using UnityEngine;

namespace Game_Scripts.Monster{
    public class MonsterSingleton: Singleton<MonsterSingleton>{
        [SerializeField] private AudioClip[] _audioClipsArrayWalkingAround;
        [SerializeField] private AudioClip[] _audioClipsArrayWalkingToPlayer;
        [SerializeField] private AudioClip _audioClipBreathing;
        private AudioSource _audioSource;
        
        private void Awake() {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayASoundFromWalkingAroundArray() {
            var audioClip = GetARandomSoundFromArray(_audioClipsArrayWalkingAround);

            while (audioClip == _audioSource.clip  && _audioClipsArrayWalkingAround.Length > 1) {
                audioClip = GetARandomSoundFromArray(_audioClipsArrayWalkingAround);
            }

            _audioSource.clip = audioClip;
            _audioSource.Play();
        }
        
        public void PlayASoundFromWalkingToPlayerArray() {
            var audioClip = GetARandomSoundFromArray(_audioClipsArrayWalkingToPlayer);

            while (audioClip == _audioSource.clip && _audioClipsArrayWalkingToPlayer.Length > 1) {
                audioClip = GetARandomSoundFromArray(_audioClipsArrayWalkingToPlayer);
            }
            _audioSource.clip = audioClip;
            _audioSource.Play();
        }

        public void PlayBreathingSound() {
            _audioSource.clip = _audioClipBreathing;
            _audioSource.Play();
        }

        public AudioClip GetARandomSoundFromArray(AudioClip[] array) {
            var rdn = new System.Random();

            var index = rdn.Next(array.Length);

            return array[index];

        }
        
        public AudioSource AudioSource => _audioSource;
    }
}