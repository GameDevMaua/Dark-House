using System;
using Player.State_Machine;
using UnityEngine;

namespace Game_Scripts.Monster.State_Machine{
    [Serializable]
    public class WalkingRoutine : BaseMonsterState{
        private Transform[] _transformsArray;
        private int _currentTarget;
        private float _movementSpeed;
        private float _angryStateRadius;

        public override void OnStateEnter() {
            var stateMachinePlayer = _playerSingleton.GetComponent<PlayerStateMachineManager>();

            stateMachinePlayer.WalkingPlayerState.OnWalking += CheckIfItMustChangeState;
            _monsterSingleton.AudioSource.Stop();
        }

        public override void executeState() {
            WalkToNextKey(0.5f); //esse 0.5f não tem pq mudar, pois é só pra saber quando o monstro chegar na chave.
            
            if(!_monsterSingleton.AudioSource.isPlaying)
                _monsterSingleton.PlayAnAudioFromAudioArray(0);
        }
        
        
        public override void OnStateExit() {
            _monsterRigidbody.velocity = Vector2.zero;
            
            var stateMachinePlayer = _playerSingleton.GetComponent<PlayerStateMachineManager>();
            stateMachinePlayer.WalkingPlayerState.OnWalking -= CheckIfItMustChangeState;
        }

        private void WalkToNextKey(float distanceToNextKey) {
            var vectorToNextKey =  _transformsArray[CurrentTarget].position - _monsterSingleton.transform.position;
            _monsterRigidbody.velocity = (vectorToNextKey.normalized) * _movementSpeed;

            if (vectorToNextKey.magnitude <= distanceToNextKey) {
                CurrentTarget++;
            }
        }

        private void CheckIfItMustChangeState() {
            var distanceToPlayer =
                (_playerSingleton.transform.position - _monsterSingleton.transform.position).magnitude;

            if (distanceToPlayer <= _angryStateRadius) {
                _stateMachine.ChangeCurrentState(_stateMachine.WalkingNearbyPlayerState);
            }
        }
        
        private int CurrentTarget {
            get => _currentTarget;
            set {
                if (value >= _transformsArray.Length) {
                    _currentTarget = 0;
                }
                else if (value < 0) {
                    _currentTarget = _transformsArray.Length - 1;
                }
                else {
                    _currentTarget = value;
                }
            }
        }

        public WalkingRoutine(IStateMachineManager stateMachineManager, Transform[] transformsArray, float movementSpeed, float angryRadius) : base(stateMachineManager) {
            _transformsArray = transformsArray;
            _movementSpeed = movementSpeed;
            _angryStateRadius = angryRadius;
        }
    }
}