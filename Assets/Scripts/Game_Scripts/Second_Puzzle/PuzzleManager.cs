using System;
using System.Collections.Generic;
using Events;
using UnityEngine;

namespace DefaultNamespace.Second_Puzzle{
    public class PuzzleManager : MonoBehaviour{
        private int _currentIndex;
        public static event Action SucessfulInteractingEvent;
        public static event Action FailedInteractingEvent;
        
        [SerializeField] private List<string> _objsTagsList;

        private void Awake() {
            FailedInteractingEvent += ResetCurrentIndex;
            SucessfulInteractingEvent += NextIndex;
        }

        public void CheckIfInputTagIsRight(string tag) {
            if (tag == _objsTagsList[_currentIndex])
                SucessfulInteractingEvent?.Invoke();
            else
                FailedInteractingEvent?.Invoke();
        }

        private void NextIndex() {
            if (_currentIndex == _objsTagsList.Count - 1) { //se chamar a função e estiver no funial da lista, quer dizer que a senha está certa. Fim de jogo
                EventManager.InvokeOnGameWin();
                return;
            }
            _currentIndex++;
        }

        private void ResetCurrentIndex() {
            _currentIndex = 0;
        }
        
    }
}