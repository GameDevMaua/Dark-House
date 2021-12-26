using Player;

namespace Game_Scripts.Monster.State_Machine{
    public abstract class BaseMonsterState{
        
        protected IStateMachineManager _stateMachine;
        protected MonsterSingleton _monsterSingleton;
        protected PlayerSingleton _playerSingleton;

        
        protected BaseMonsterState(IStateMachineManager stateMachineManager) {
            _stateMachine = stateMachineManager;
            _monsterSingleton = MonsterSingleton.Instance;
            _playerSingleton = PlayerSingleton.Instance;
        }
        
        
        public virtual void executeState() {
        }

        public virtual void OnStateExit() {
        }
        
        public virtual void OnStateEnter() {
        }

    }
}