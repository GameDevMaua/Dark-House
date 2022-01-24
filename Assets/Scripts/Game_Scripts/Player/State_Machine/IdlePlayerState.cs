namespace Player.State_Machine{
    public class IdlePlayerState : BasePlayerState{

        public override void executeState() {
            if (_playerRigidbody.velocity.magnitude >= _playerSingleton.MovingVelocity) {
                PlayerStateMachine.ChangeCurrentState(PlayerStateMachine.WalkingPlayerState);
            }
            
            
        }

        public IdlePlayerState(PlayerStateMachineManager playerStateMachineManager) : base(playerStateMachineManager) {
        }
    }
}