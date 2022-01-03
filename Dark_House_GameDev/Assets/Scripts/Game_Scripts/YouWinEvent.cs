using Player.Player_Collisions;
using UnityEngine;

namespace DefaultNamespace{
    public class YouWinEvent : MonoBehaviour{
        private void Start() {
            var doorCollision = GameObject.FindWithTag("Door").GetComponent<DoorCollision>();

            doorCollision.OnWinGame += WinningGame;

        }

        public void WinningGame() {
            print("O evento de vencer o jogo foi chamado!");
        }
        
    }
}