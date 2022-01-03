using System;
using Player.State_Machine;
using UnityEngine;

namespace Game_Scripts.Monster.State_Machine{
    [Serializable]
    public class WalkingRoutine : BaseMonsterState{
        private Transform[] _transformsArray;
        private int _currentTargetIndexIndex;
        private float _movementSpeed;
        private float _angryStateRadius;

        public override void OnStateEnter() { //inscrevendo no evento
            _stateMachinePlayer.WalkingPlayerState.OnWalking += CheckIfItMustChangeState;
        }

        public override void executeState() {
            WalkToNextKey(0.5f); //esse 0.5f não tem pq mudar, pois é só pra saber quando o monstro chegar na chave.
            
            if(!_monsterSingleton.AudioSource.isPlaying)
                _monsterSingleton.PlayAnAudioFromAudioArray(0);
        }
        
        
        public override void OnStateExit() {
            _stateMachinePlayer.WalkingPlayerState.OnWalking -= CheckIfItMustChangeState;
        }

        private void WalkToNextKey(float distanceToNextKey) {
            var vectorToNextKey =  _transformsArray[CurrentTargetIndex].position - _monsterSingleton.transform.position;
            _monsterRigidbody.velocity = (vectorToNextKey.normalized) * _movementSpeed;

            if (vectorToNextKey.magnitude <= distanceToNextKey) {
                CurrentTargetIndex++;
            }
        }

        private void CheckIfItMustChangeState() {
            if (_distanceToPlayer <= _angryStateRadius) 
                _stateMachineMonster.ChangeCurrentState(_stateMachineMonster.WalkingNearbyPlayerState);
            
        }
        
        private int CurrentTargetIndex {
            get => _currentTargetIndexIndex;
            set {
                if (value >= _transformsArray.Length) {
                    _currentTargetIndexIndex = 0;
                }
                else if (value < 0) {
                    _currentTargetIndexIndex = _transformsArray.Length - 1;
                }
                else {
                    _currentTargetIndexIndex = value;
                }
            }
        }

        public WalkingRoutine(Transform[] transformsArray, float movementSpeed, float angryRadius) {
            _transformsArray = transformsArray;
            _movementSpeed = movementSpeed;
            _angryStateRadius = angryRadius;
        }
    }
}