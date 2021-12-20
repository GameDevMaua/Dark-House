using UnityEngine;

namespace Player.State_Machine{
    public class IdleState : BaseState{

        public override void executeState() {
            if (_playerRigidbody.velocity.magnitude >= _playerSingleton.MovingVelocity) {
                _stateMachine.ChangeState(_stateMachine.WalkingState);
            }
            
            Debug.Log("Parado!");
            
        }

        public IdleState(StateMachineManager stateMachineManager) : base(stateMachineManager) {
        }
    }
}