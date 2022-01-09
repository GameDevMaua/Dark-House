using System;
using Events;
using Game_Scripts.Monster;
using Game_Scripts.Monster.State_Machine;
using UnityEngine;

namespace Player.State_Machine{
    public class WalkingPlayerState : BasePlayerState{
        private AudioSource _audioSource;

        public event Action OnWalking;


        public override void OnStateEnter() { 
            _audioSource.Play();
            SubscribeOnGameOverEvent(EndGame);   
        }

        public override void OnStateExit() {
            _audioSource.Stop();
            UnsubscribeOnGameOverEvent(EndGame);
        }

        public override void executeState() {
            OnWalking?.Invoke();
            if (_playerRigidbody.velocity.magnitude <= _playerSingleton.MovingVelocity * 0.20f) {
                PlayerStateMachine.ChangeCurrentState(PlayerStateMachine.IdlePlayerState);
            }
        }

        private void SubscribeOnGameOverEvent(Action function) {

            EventManager.OnGameOver += function;
        }
        private void UnsubscribeOnGameOverEvent(Action function) {

            EventManager.OnGameOver -= function;
        }
        
        public void EndGame() {
            PlayerStateMachine.ChangeCurrentState(PlayerStateMachine.DeadState);
        }

        public WalkingPlayerState(PlayerStateMachineManager playerStateMachineManager, AudioSource audioSource) : base(playerStateMachineManager) {
            _audioSource = audioSource;
        }
    }
}