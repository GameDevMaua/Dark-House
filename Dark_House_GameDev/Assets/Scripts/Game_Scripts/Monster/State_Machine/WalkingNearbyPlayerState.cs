using System;
using UnityEngine;

namespace Game_Scripts.Monster.State_Machine{
    public class WalkingNearbyPlayerState : BaseMonsterState{
        private float _movementSpeed;
        private Vector3 _velocityVector;
        private float _cooldown;
        private float _timer;
        private bool _jafoi;
        private float _gameOverRadius;
        private float _distanceToGoBackToRoutineState;

        public event Action OnGameOver;

        public override void OnStateEnter() {
            _velocityVector = (_playerSingleton.transform.position - _monsterSingleton.transform.position).normalized *
                              _movementSpeed;
            _monsterRigidbody.velocity = _velocityVector;
            
            _jafoi = false;
            Timer = _cooldown;
            _monsterSingleton.AudioSource.Stop();

        }
        
        public override void executeState() { //todo:Esse jeito de ver se o evento já foi inscrito me parece horrível
            Timer -= Time.deltaTime;
            if (Timer <= 0 && !_jafoi) {
                _jafoi = true;
                SubscribeAtOnWalkingEvent();
            }
            
            
            if(!_monsterSingleton.AudioSource.isPlaying)
                _monsterSingleton.PlayAnAudioFromAudioArray(1);

            if (_distanceToPlayer >= _distanceToGoBackToRoutineState) {
                _stateMachineMonster.ChangeCurrentState(_stateMachineMonster.WalkingRoutineState);
            }
        }

        public override void OnStateExit() {
            _stateMachinePlayer.WalkingPlayerState.OnWalking -= VerifyIfTheGameIsOver;
            _monsterSingleton.AudioSource.Stop();
        }


        private void VerifyIfTheGameIsOver() {
                //se o player estiver dentro de um range. fim de jogo      

                if (!(_distanceToPlayer <= _gameOverRadius)) return;
                
                OnGameOver?.Invoke();
                _stateMachineMonster.ChangeCurrentState(_stateMachineMonster.NullState);
                
        }
         private void SubscribeAtOnWalkingEvent() {
             _stateMachinePlayer.WalkingPlayerState.OnWalking += VerifyIfTheGameIsOver;
             
        }

         private float Timer {
             get => _timer;
             set {
                 if (value < 0) {
                     _timer = 0;
                 }
                 else {
                     _timer = value;
                     
                 }
             }
         }

         public WalkingNearbyPlayerState(float movementSpeed, float cooldown, float gameOverRadius, float distanceToGoBackToRoutineState) {
            _movementSpeed = movementSpeed;
            _cooldown = cooldown;
            _gameOverRadius = gameOverRadius;
            _distanceToGoBackToRoutineState = distanceToGoBackToRoutineState;
         }
    }
}