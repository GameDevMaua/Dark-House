using Game_Scripts.Monster;
using Game_Scripts.Monster.State_Machine;
using UnityEngine;

namespace DefaultNamespace{
    public class YouLoseEvent : MonoBehaviour{
        
        private void Start() {
            var monsterStatemachine = MonsterSingleton.Instance.GetComponent<MonsterStateMachineManager>();

            monsterStatemachine.WalkingNearbyPlayerState.OnGameOver += DeactivateAllAudioGuides;
        }



        public void DeactivateAllAudioGuides() {
            var audioGuidesList = GameObject.FindGameObjectsWithTag("Guide");
            print("Perdeste");

            foreach (var item in audioGuidesList) {
                item.SetActive(false);
            }
        }
    }
}