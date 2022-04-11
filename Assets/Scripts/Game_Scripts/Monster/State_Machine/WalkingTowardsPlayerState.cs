using Events;
using UnityEngine;

namespace Game_Scripts.Monster.State_Machine{
    public class WalkingTowardsPlayerState : BaseMonsterState{
        private float _movementSpeed;
        private Vector3 _velocityVector;
        private bool _isSubscribedOnPlayerWalkingEvent;
        private float _distanceToSmellPlayerState;
        
        
        public override void OnExecuteState() { 
            
            _MoveTowardsPlayer();

            if(!_monsterSingleton.AudioSource.isPlaying)
                _monsterSingleton.PlayASoundFromWalkingToPlayerArray();

            if (_distanceToPlayer <= _distanceToSmellPlayerState) {
                _stateMachineMonster.ChangeCurrentState(_stateMachineMonster.SmellingState); //ir para o estado de cheirar o player
            }
        }
        
        private void _MoveTowardsPlayer() {
            _velocityVector = (_playerSingleton.transform.position - _monsterSingleton.transform.position).normalized *
                              _movementSpeed;
            _monsterRigidbody.velocity = _velocityVector;
        }
        
        
         public WalkingTowardsPlayerState(float movementSpeed, float distanceToSmellPlayerState) {
            _movementSpeed = movementSpeed;
            _distanceToSmellPlayerState = distanceToSmellPlayerState;
         }
    }
}