using Events;
using UnityEngine;

namespace DefaultNamespace{
    public class YouLoseEvent : MonoBehaviour{
        
        private void Start() {
            EventManager.OnGameOver += DeactivateAllAudioGuides;
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