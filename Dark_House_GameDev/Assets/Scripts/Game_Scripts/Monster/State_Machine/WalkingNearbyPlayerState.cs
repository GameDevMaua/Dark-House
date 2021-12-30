using System;
using Player.State_Machine;
using UnityEngine;

namespace Game_Scripts.Monster.State_Machine{
    public class WalkingNearbyPlayerState : BaseMonsterState{
        private float _movementSpeed;
        private Vector3 _velocityVector;
        private PlayerStateMachineManager _playerStateMachinePlayer;
        private float _cooldown;
        private float _timer;
        private bool _jafoi = false;
        private float _gameOverRadious;
        private float _distanceToGoBackToRoutineState;

        public event Action OnGameOver;

        public override void OnStateEnter() {
            _velocityVector = (_playerSingleton.transform.position - _monsterSingleton.transform.position).normalized *
                              _movementSpeed;

            _monsterRigidbody.velocity = _velocityVector;
            
            _playerStateMachinePlayer = _playerSingleton.GetComponent<PlayerStateMachineManager>();

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

            var distanceToPlayer =
                (_playerSingleton.transform.position - _monsterSingleton.transform.position).magnitude;

            if (distanceToPlayer >= _distanceToGoBackToRoutineState) {
                _stateMachine.ChangeCurrentState(_stateMachine.WalkingRoutineState);
            }
        }

        public override void OnStateExit() {
            _playerStateMachinePlayer.WalkingPlayerState.OnWalking -= VerifyIfTheGameIsOver;
        }


        private void VerifyIfTheGameIsOver() {
                //se o player estiver dentro de um range. fim de jogo      

                var distance = (_playerSingleton.transform.position - _monsterSingleton.transform.position).magnitude;

                if (!(distance <= _gameOverRadious)) return;
                
                OnGameOver?.Invoke();
                _stateMachine.ChangeCurrentState(_stateMachine.NullState);
                
        }
         private void SubscribeAtOnWalkingEvent() {
             _playerStateMachinePlayer.WalkingPlayerState.OnWalking += VerifyIfTheGameIsOver;
             
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

         public WalkingNearbyPlayerState(IStateMachineManager stateMachineManager, float movementSpeed, float cooldown, float gameOverRadious, float distanceToGoBackToRoutineState) : base(stateMachineManager) {
            _movementSpeed = movementSpeed;
            _cooldown = cooldown;
            _gameOverRadious = gameOverRadious;
            _distanceToGoBackToRoutineState = distanceToGoBackToRoutineState;
         }
    }
}