using UnityEngine;

namespace Player.State_Machine{
    public class IdlePlayerState : BasePlayerState{

        public override void executeState() {
            if (_playerRigidbody.velocity.magnitude >= _playerSingleton.MovingVelocity) {
                _stateMachine.ChangeState(_stateMachine.WalkingPlayerState);
            }
            
            
        }

        public IdlePlayerState(StateMachineManager stateMachineManager) : base(stateMachineManager) {
        }
    }
}