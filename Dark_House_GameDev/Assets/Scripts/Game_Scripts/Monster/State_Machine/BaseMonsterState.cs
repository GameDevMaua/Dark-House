namespace Game_Scripts.Monster.State_Machine{
    public abstract class BaseMonsterState{
        
        protected StateMachineManager _stateMachine;

        
        protected BaseMonsterState(StateMachineManager stateMachineManager) {
            _stateMachine = stateMachineManager;
        }
        
        
        public virtual void executeState() {
        }

        public virtual void OnStateExit() {
        }
        
        public virtual void OnStateEnter() {
        }

    }
}