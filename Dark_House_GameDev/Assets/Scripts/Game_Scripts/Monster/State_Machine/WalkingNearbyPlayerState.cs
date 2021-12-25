using UnityEngine;

namespace Game_Scripts.Monster.State_Machine{
    public class WalkingNearbyPlayerState : BaseMonsterState{
        public override void executeState() {
            Debug.Log("Walking Nearby");
        }

        public WalkingNearbyPlayerState(StateMachineManager stateMachineManager) : base(stateMachineManager) {
        }
    }
}