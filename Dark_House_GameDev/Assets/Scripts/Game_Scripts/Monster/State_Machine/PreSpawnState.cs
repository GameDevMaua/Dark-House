
using System;
using UnityEngine;

namespace Game_Scripts.Monster.State_Machine{
    [Serializable]
    public class PreSpawnState : BaseMonsterState{
        private float _cooldownToCheckSpawn;
        private float _probabilityToSpawn;
        

        public override void executeState() {
            //Verificar quando o monstro irá nascer

            CooldownToCheckSpawn -= Time.deltaTime;

            if (CooldownToCheckSpawn > 0) 
                return;
            
            _stateMachine.ChangeCurrentState(_stateMachine.WalkingRandomlyState);
            
        }
        
        public PreSpawnState(IStateMachineManager stateMachineManager, float cooldown, float probability) : base(stateMachineManager) {
            CooldownToCheckSpawn = cooldown;
            ProbabilityToSpawn = probability;
        }
        
        public float CooldownToCheckSpawn {
            get => _cooldownToCheckSpawn;
            set {
                if(value >= 0)
                    _cooldownToCheckSpawn = value;
                else {
                    _cooldownToCheckSpawn = 0f;
                }
            }
        }

        public float ProbabilityToSpawn {
            get => _probabilityToSpawn;
            set {
                if(value >= 0)
                    _probabilityToSpawn = value;
                else {
                    _probabilityToSpawn = 0f;
                }
            }
        }

    }
}