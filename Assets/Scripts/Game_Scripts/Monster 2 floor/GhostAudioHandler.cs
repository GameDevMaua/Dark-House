using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Monster_2_floor{
    [RequireComponent(typeof(AudioSource))]
    public class GhostAudioHandler : MonoBehaviour{
        [SerializeField] private List<AudioClip> _audioClipsList;
        private AudioSource _audioSource;

        private void Awake() {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable() {
            Ghost2Timer.CurrentTimerPartIsEvent += PlayAnAudioFromList;
            CheckIfPlayerWithinArea.PlayerLeftedAreaEvent += StopPlayingAudios;
        }

        private void OnDisable() {
            Ghost2Timer.CurrentTimerPartIsEvent -= PlayAnAudioFromList;
            CheckIfPlayerWithinArea.PlayerLeftedAreaEvent -= StopPlayingAudios;
        }

        public void PlayAnAudioFromList(int index) {
            if(_audioSource.isPlaying)
                StopPlayingAudios();
            
            _audioSource.clip = _audioClipsList[index];
            _audioSource.Play();
        }

        public void StopPlayingAudios() {
            _audioSource.Stop();
        }

        public int AudioListLength => _audioClipsList.Count;
    }
}