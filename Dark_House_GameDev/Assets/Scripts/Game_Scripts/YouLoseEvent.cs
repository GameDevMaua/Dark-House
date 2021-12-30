using Game_Scripts.Monster;
using Game_Scripts.Monster.State_Machine;
using UnityEngine;

namespace DefaultNamespace{
    public class YouLoseEvent : MonoBehaviour{
        private void Start() {
            var monsterStatemachine = MonsterSingleton.Instance.GetComponent<MonsterStateMachineManager>();

            monsterStatemachine.WalkingNearbyPlayerState.OnGameOver += kappa;
        }

        public void kappa() {
            print("O evento de game over foi chamado!");
        }
    }
}