using UnityEngine;

namespace Game_Scripts.Monster.State_Machine{
    public class WalkingRandomlyState : BaseMonsterState{
        
        public override void executeState() {
            Debug.Log("Walking Randomly");
        }

        
        public WalkingRandomlyState(StateMachineManager stateMachineManager) : base(stateMachineManager) {
        }
    }
}

/*
 *Para saber se o player fez barulho de novo, podemos usar o observer pattern para emitir um evento quando o player
 * sair do estado "Idle" para o estado "Walking"
 *
 * quando isso ocorrer, nós atualizamos o estado do monstro para "Walking Nearby Player"
 */