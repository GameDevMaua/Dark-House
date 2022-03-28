using System;
using System.Collections.Generic;
using Events;
using UnityEngine;

namespace DefaultNamespace.Second_Puzzle{
    public class PuzzleManager : MonoBehaviour{
        private int _currentIndex;
        public static event Action SucessfullInteractingEvent;
        public static event Action FailedInteractingEvent;
        
        [SerializeField] private List<GameObject> _gameObjectsList;

        private void Awake() {
            FailedInteractingEvent += ResetCurrentIndex;
            SucessfullInteractingEvent += NextIndex;
        }

        private void OnDestroy() {
            FailedInteractingEvent -= ResetCurrentIndex;
            SucessfullInteractingEvent -= NextIndex;
        }

        public void CheckIfInputObjIsRight(GameObject gameObject) {
            if (gameObject == _gameObjectsList[_currentIndex])
                SucessfullInteractingEvent?.Invoke();
            else
                FailedInteractingEvent?.Invoke();
        }

        private void NextIndex() {
            if (_currentIndex == _gameObjectsList.Count - 1) { //se chamar a função e estiver no final da lista, quer dizer que a senha está certa. Fim de jogo
                EventManager.InvokeOnGameWin();
                return;
            }
            _currentIndex++;
        }

        private void ResetCurrentIndex() {
            _currentIndex = 0;
        }

        public int CurrentIndex => _currentIndex;

        public int ListLength => _gameObjectsList.Count;
    }
}