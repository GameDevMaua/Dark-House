using System;
using UnityEngine;

namespace Player.State_Machine{
    public class WalkingPlayerState : BasePlayerState{
        private AudioSource _audioSource;

        public event Action OnWalking;


        public override void OnStateEnter() {
            _audioSource.Play();
            
        }

        public override void OnStateExit() {
            _audioSource.Stop();
        }

        public override void executeState() {
            OnWalking?.Invoke();
            if (_playerRigidbody.velocity.magnitude <= _playerSingleton.MovingVelocity * 0.20f) {
                PlayerStateMachine.ChangeCurrentState(PlayerStateMachine.IdlePlayerState);
            }
        }

        public WalkingPlayerState(PlayerStateMachineManager playerStateMachineManager, AudioSource audioSource) : base(playerStateMachineManager) {
            _audioSource = audioSource;
        }
    }
}