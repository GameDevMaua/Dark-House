using UnityEngine;

namespace Game_Scripts.Monster.State_Machine{
    public class PreSpawnState : BaseMonsterState{

        private float _cooldown = 10f;
        
        public override void executeState() {
            Debug.Log("Pre-Spawn state");
            _cooldown -= Time.deltaTime;
            
            if(_cooldown <= 0)
                _stateMachine.ChangeCurrentState(_stateMachine.WalkingRandomlyState);
        }
        
        public PreSpawnState(StateMachineManager stateMachineManager) : base(stateMachineManager) {
        }
    }
}