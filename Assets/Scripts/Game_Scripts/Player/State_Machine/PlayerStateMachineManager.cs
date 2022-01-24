using System;
using Game_Scripts.Scriptable_Objects;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Player.State_Machine{
    [Serializable]
    public class PlayerStateMachineManager : MonoBehaviour{
        private BasePlayerState _currentPlayerState;
      
        private WalkingPlayerState _walkingPlayerState;
        private IdlePlayerState _idlePlayerState;
        private DeadState _deadState;

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _endGameAudioClip;
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private StringSoundDictionary _soundDictionary;
        [SerializeField] private AudioClip _defaultStepSound;

        
        private void Awake() {
            _walkingPlayerState = new WalkingPlayerState(this, _audioSource, _tilemap, _soundDictionary, _defaultStepSound);
            _idlePlayerState = new IdlePlayerState(this);
            _deadState = new DeadState(this, _audioSource, _endGameAudioClip);

            _currentPlayerState = _idlePlayerState;
        }

        private void Start() {
            _currentPlayerState.OnStateEnter();
        }

        private void Update() {
            _currentPlayerState.executeState();
        }

        public void ChangeCurrentState(BasePlayerState nextPlayerState) {
            _currentPlayerState.OnStateExit();
            _currentPlayerState = nextPlayerState;
            _currentPlayerState.OnStateEnter();
        }
        
        
        
        public WalkingPlayerState WalkingPlayerState => _walkingPlayerState;

        public IdlePlayerState IdlePlayerState => _idlePlayerState;

        public DeadState DeadState => _deadState;
    }
}