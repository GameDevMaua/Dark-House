using System;
using UnityEngine;

namespace Player.State_Machine{
    [Serializable]
    public class StateMachineManager : MonoBehaviour{
        private BaseState _currentState;
      
        private WalkingState _walkingState;
        private IdleState _idleState;

        [SerializeField] private AudioSource _audioSource;

        
        private void Start() {
            _walkingState = new WalkingState(this, _audioSource);
            _idleState = new IdleState(this);

            _currentState = _idleState;
        }

        private void Update() {
            _currentState.executeState();
        }

        public void ChangeState(BaseState nextState) {
            _currentState.OnStateExit();
            _currentState = nextState;
            _currentState.OnStateEnter();
        }
        
        
        
        public WalkingState WalkingState {
            get => _walkingState;
        }

        public IdleState IdleState {
            get => _idleState;
        }
        
    }
}