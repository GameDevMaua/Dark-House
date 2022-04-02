using System;
using UnityEngine;

namespace Game_Scripts.Keys_Manager{
    [RequireComponent(typeof(AudioSource), typeof(KeyController))]
    public class KeySoundHandler : MonoBehaviour{
        [SerializeField] private AudioClip _activedSound;
        [SerializeField] private AudioClip _deactivedSound;
        [SerializeField] private AudioClip _collectedSound;

        private AudioSource _audioSource;
        private KeyController _keyController;

        private void Awake() {
            _keyController = GetComponent<KeyController>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start() {

            _keyController.OnCollectingEvent += () => {PlaySound(false, _collectedSound); };
            
            if (!_keyController.CurrentActive) {
                PlaySound(true, _deactivedSound);
            }
            else {
                PlaySound(true, _activedSound);
            }
        }

        private void PlaySound(bool loop, AudioClip clip) {
            _audioSource.loop = loop;
            _audioSource.clip = clip;
            _audioSource.Play();
        }
        
    }
}