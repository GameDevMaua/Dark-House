using Player;
using Player.State_Machine;
using UnityEngine;

namespace Game_Scripts.Monster.State_Machine{
    public abstract class BaseMonsterState{
        
        protected IStateMachineManager _stateMachineMonster;
        protected PlayerStateMachineManager _stateMachinePlayer;
        protected MonsterSingleton _monsterSingleton;
        protected PlayerSingleton _playerSingleton;
        protected Rigidbody2D _monsterRigidbody;

        protected float _distanceToPlayer => (_playerSingleton.transform.position - _monsterSingleton.transform.position).magnitude;


        protected BaseMonsterState() {
            _monsterSingleton = MonsterSingleton.Instance;
            _playerSingleton = PlayerSingleton.Instance;
            _monsterRigidbody = _monsterSingleton.GetComponent<Rigidbody2D>();
            _stateMachinePlayer = _playerSingleton.GetComponent<PlayerStateMachineManager>();
            _stateMachineMonster = _monsterSingleton.GetComponent<IStateMachineManager>();
        }
        
        
        public virtual void executeState() {
        }

        public virtual void OnStateExit() {
        }
        
        public virtual void OnStateEnter() {
        }

    }
}