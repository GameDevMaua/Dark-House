using System;
using UnityEngine;
using Random = System.Random;

//todo:Refatorar essa classe, pois ela claramente fere o SRP

namespace Game_Scripts.Monster.State_Machine{
    [Serializable]
    public class PreSpawnState : BaseMonsterState{
        private float _cooldownToCheckSpawn;
        private float _probabilityToSpawnInDecimals;
        private float _timer;


        public override void OnStateEnter() {
            _timer = _cooldownToCheckSpawn;
        }


        public override void executeState() {
            //Verificar quando o monstro irá nascer
            

            Timer -= Time.deltaTime; //Cuidar do timer

            if (Timer > 0) 
                return;

            var randomObject = new Random(); //Definir se vai ou não spawnar
            var diceNumber = randomObject.NextDouble();
            if (diceNumber < _probabilityToSpawnInDecimals)
                _stateMachine.ChangeCurrentState(_stateMachine.WalkingRandomlyState); //spawnar
            else
                Timer = _cooldownToCheckSpawn;

        }
        
        public PreSpawnState(IStateMachineManager stateMachineManager, float cooldown, float probability) : base(stateMachineManager) {
            CooldownToCheckSpawn = cooldown;
            ProbabilityToSpawnInDecimals = probability;
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

        public float ProbabilityToSpawnInDecimals {
            get => _probabilityToSpawnInDecimals;
            set {
                if(value >= 0)
                    _probabilityToSpawnInDecimals = value;
                else if (value >= 1)
                    _probabilityToSpawnInDecimals = 1f;
                else {
                    _probabilityToSpawnInDecimals = 0f;
                }
            }
        }

        public float Timer {
            get => _timer;
            set {
                if(value >= 0)
                    _timer = value;
                else {
                    _timer = 0f;
                }
            }
        }
    }
}