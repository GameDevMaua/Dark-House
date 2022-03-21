using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Monster_2_floor{
    [RequireComponent(typeof(AudioSource))]
    public class GhostAudioHandler : MonoBehaviour{
        [SerializeField] private List<AudioClip> _audioClipsList;
        private AudioSource _audioSource;

        private AreaTimer _areaTimer;
        
        private void Awake() {
            _audioSource = GetComponent<AudioSource>();
            _areaTimer = GetComponent<AreaTimer>();
        }

        private void OnEnable() {
            _areaTimer.TimerFractionHandler.TimerIndexEvent += PlayAnAudioFromList;
        }

        private void OnDisable() {
            _areaTimer.TimerFractionHandler.TimerIndexEvent -= PlayAnAudioFromList;
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