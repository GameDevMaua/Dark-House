using System;
using UnityEngine;

namespace Player{
    public class WallDetectorAudioPlayer : MonoBehaviour{
        private AudioSource _audioSource;

        private void Start() {
            _audioSource = GetComponentInChildren<AudioSource>();
        }

        private void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.tag == "Wall" && !_audioSource.isPlaying) {
                _audioSource.Play();
            }
                
        }
        
    }
}