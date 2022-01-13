using Events;
using UnityEngine;

namespace DefaultNamespace{
    public class YouWinEvent : MonoBehaviour{
        private void Start() {

            EventManager.OnGameWin += WinningGame;
        }

        public void WinningGame() {
            print("O evento de vencer o jogo foi chamado!");
        }
        
    }
}