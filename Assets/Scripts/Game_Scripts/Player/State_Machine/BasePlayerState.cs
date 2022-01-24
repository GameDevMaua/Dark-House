using UnityEngine;

namespace Player.State_Machine{
    public abstract class BasePlayerState{
        protected PlayerStateMachineManager PlayerStateMachine;
        protected PlayerSingleton _playerSingleton;
        protected Rigidbody2D _playerRigidbody;
        
        
        
        protected BasePlayerState(PlayerStateMachineManager playerStateMachineManager) {
            PlayerStateMachine = playerStateMachineManager;
            _playerSingleton = PlayerSingleton.Instance;
            _playerRigidbody = _playerSingleton.GetComponent<Rigidbody2D>();
        }
        
        public virtual void executeState() {
        }

        public virtual void OnStateExit() {
            
        }


        public virtual void OnStateEnter() {
            
        }

    }
}