using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace.Second_Puzzle{
    [RequireComponent(typeof(AudioSource))]
    public class TottensAudioManager : MonoBehaviour{
        [SerializeField] private AudioClip _failAudioResponse;
        [SerializeField] private AudioClip _sucessfullAudioResponse;
        [SerializeField] private AudioClip _defaultAudio;

        private AudioSource _audioSource;

        private void Awake() {
            _audioSource = GetComponent<AudioSource>();
            PlayDefaultSound();
        }

        private void Start() {
            PuzzleManager.FailedInteractingEvent += StartPlayFailAudioCorountine;
            PuzzleManager.SucessfullInteractingEvent += StartPlaySucessAudioCorountine;
        }

        private void OnDestroy() {
            PuzzleManager.FailedInteractingEvent -= StartPlayFailAudioCorountine;
            PuzzleManager.SucessfullInteractingEvent -= StartPlaySucessAudioCorountine;
        }

        private void StartPlayFailAudioCorountine() {
            StartCoroutine(PlayFailAudio());
        }
        
        private void StartPlaySucessAudioCorountine() {
            StartCoroutine(PlaySucessAudio());
        }
        
        private IEnumerator PlayFailAudio() {
            _audioSource.Stop();
            _audioSource.clip = _failAudioResponse;
            _audioSource.Play();

            yield return new WaitForSeconds(_failAudioResponse.length);
            
            PlayDefaultSound();
        }
        
        private IEnumerator PlaySucessAudio() {
            _audioSource.Stop();
            _audioSource.clip = _sucessfullAudioResponse;
            _audioSource.Play();
            
            yield return new WaitForSeconds(_sucessfullAudioResponse.length);
            
            PlayDefaultSound();
        }

        private void PlayDefaultSound() {
            _audioSource.clip = _defaultAudio;
            _audioSource.Play();
        }
        
        
    }
}