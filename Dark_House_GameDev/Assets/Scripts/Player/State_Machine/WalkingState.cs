using UnityEngine;

namespace Player.State_Machine{
    public class WalkingState : BaseState{
        private AudioSource _audioSource;


        public override void OnStateEnter() {
            _audioSource.Play();
        }

        public override void OnStateExit() {
            _audioSource.Stop();
        }

        public override void executeState() {
            if (_playerRigidbody.velocity.magnitude <= _playerSingleton.MovingVelocity * 0.20f) {
                _stateMachine.ChangeState(_stateMachine.IdleState);
            }
            Debug.Log("Andando!");
        }

        public WalkingState(StateMachineManager stateMachineManager, AudioSource audioSource) : base(stateMachineManager) {
            _audioSource = audioSource;
        }
    }
}