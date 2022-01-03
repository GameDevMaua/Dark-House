using System;
using UnityEngine;

namespace Player.State_Machine{
    [Serializable]
    public class PlayerStateMachineManager : MonoBehaviour{
        private BasePlayerState _currentPlayerState;
      
        private WalkingPlayerState _walkingPlayerState;
        private IdlePlayerState _idlePlayerState;
        private NullState _nullState;

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _endGameAudioClip;

        
        private void Awake() {
            _walkingPlayerState = new WalkingPlayerState(this, _audioSource);
            _idlePlayerState = new IdlePlayerState(this);
            _nullState = new NullState(this, _audioSource, _endGameAudioClip);

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

        public NullState NullState => _nullState;
    }
}