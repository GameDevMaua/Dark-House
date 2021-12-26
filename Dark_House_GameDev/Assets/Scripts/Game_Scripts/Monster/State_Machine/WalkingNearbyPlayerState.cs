using UnityEngine;

namespace Game_Scripts.Monster.State_Machine{
    public class WalkingNearbyPlayerState : BaseMonsterState{
        public override void OnStateEnter() {
            //determinar a direção do player, caso ela seja inválida, determinar novamente
        }

        public override void executeState() {
            //aplicar a velocidade com a direção determinada
        }

        public WalkingNearbyPlayerState(IStateMachineManager stateMachineManager) : base(stateMachineManager) {
        }
    }
}