using Player;
using UnityEngine;

namespace Game_Scripts.Monster.State_Machine{
    public abstract class BaseMonsterState{
        
        protected IStateMachineManager _stateMachine;
        protected MonsterSingleton _monsterSingleton;
        protected PlayerSingleton _playerSingleton;
        protected Rigidbody2D _monsterRigidbody;
        protected float GOBackToPreSpawnStateRadiousPreSpawn;

        
        protected BaseMonsterState(IStateMachineManager stateMachineManager, float radiousPreSpawn) {
            _stateMachine = stateMachineManager;
            _monsterSingleton = MonsterSingleton.Instance;
            _playerSingleton = PlayerSingleton.Instance;
            _monsterRigidbody = _monsterSingleton.GetComponent<Rigidbody2D>();
            GOBackToPreSpawnStateRadiousPreSpawn = radiousPreSpawn;
        }
        
        
        public virtual void executeState() {
        }

        public virtual void OnStateExit() {
        }
        
        public virtual void OnStateEnter() {
        }

    }
}