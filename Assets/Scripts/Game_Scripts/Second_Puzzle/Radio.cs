using UnityEngine;

namespace DefaultNamespace.Second_Puzzle{
    [RequireComponent(typeof(AudioSource))]
    public class Radio : MonoBehaviour{
        [SerializeField] private AudioClip[] _audioClipsArray;
        [SerializeField] private PuzzleManager _puzzleManager;

        private AudioSource _audioSource;
        private void Awake() {
            _audioSource = GetComponent<AudioSource>();
            
            _audioSource.clip = _audioClipsArray[0];
            _audioSource.Play();

        }

        private void Start() {
            PuzzleManager.FailedInteractingEvent += UpdateCurrentClipAndPlay;
            PuzzleManager.SucessfullInteractingEvent += UpdateCurrentClipAndPlay;
        }

        private void OnDestroy() {
            PuzzleManager.FailedInteractingEvent -= UpdateCurrentClipAndPlay;
            PuzzleManager.SucessfullInteractingEvent -= UpdateCurrentClipAndPlay;
        }

        private void UpdateCurrentClipAndPlay() {
            var i = _puzzleManager.CurrentIndex;
            _audioSource.clip = _audioClipsArray[i];
            
            _audioSource.Play();
        }
    }
}