using Game_Scripts.Monster;
using Game_Scripts.Monster.State_Machine;
using Player;
using UnityEngine;

namespace DefaultNamespace{
    public class YouLoseEvent : MonoBehaviour{
        [SerializeField] private AudioClip _audio;
        
        private void Start() {
            var monsterStatemachine = MonsterSingleton.Instance.GetComponent<MonsterStateMachineManager>();

            monsterStatemachine.WalkingNearbyPlayerState.OnGameOver += kappa;
            monsterStatemachine.WalkingNearbyPlayerState.OnGameOver += otherKappa;
        }

        public void kappa() {
            var a = PlayerSingleton.Instance.GetComponent<AudioSource>();
            a.clip = _audio;
            a.Play();
        }


        public void otherKappa() {
            var a = GameObject.FindGameObjectsWithTag("Guide");

            foreach (var item in a) {
                item.SetActive(false);
            }
        }
    }
}