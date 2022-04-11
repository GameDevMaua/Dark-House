using Events;
using UnityEngine;

namespace Game_Scripts.Monster.State_Machine{
    public class SmellingState : BaseMonsterState{
        private float _smellStateDurationInSeconds;
        private float _endGameCooldown;

        private float _timer;

        public override void OnStateEnter() {
            base.OnStateEnter();
            _monsterSingleton.PlayBreathingSound();
            
            _monsterRigidbody.velocity = Vector3.zero;

            _stateMachinePlayer.WalkingPlayerState.OnWalking += EndGame;
            _timer = _smellStateDurationInSeconds;
        }

        public override void OnExecuteState() {
            _timer -= Time.deltaTime;
            
            if (_timer <= 0)
                _stateMachineMonster.ChangeCurrentState(_stateMachineMonster.WalkingRoutineState);

        }

        public override void OnStateExit() {
            base.OnStateExit();
            _stateMachinePlayer.WalkingPlayerState.OnWalking -= EndGame;
        }

        private void EndGame() {
            if(_timer <= _smellStateDurationInSeconds - _endGameCooldown) {
                EventManager.InvokeOnPlayerDeath();
                _stateMachineMonster.ChangeCurrentState(_stateMachineMonster.NullState);
            }
        }
        
        public SmellingState(float smellStateDurationInSeconds, float endGameCooldown) {
            _smellStateDurationInSeconds = smellStateDurationInSeconds;
            _endGameCooldown = endGameCooldown;
        }
    }
}