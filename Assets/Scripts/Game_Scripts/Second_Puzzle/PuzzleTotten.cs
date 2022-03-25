using System;
using UnityEngine;

namespace DefaultNamespace.Second_Puzzle{
    [RequireComponent(typeof(CheckIfPlayerWithinArea))]
    public class PuzzleTotten : MonoBehaviour{
        private CheckIfPlayerWithinArea _checkIfPlayerWithinArea;

        [SerializeField] private PuzzleManager _puzzleManager;

        private void Awake() {
            _checkIfPlayerWithinArea = GetComponent<CheckIfPlayerWithinArea>();
        }
        
        //Vou utilizar o sistema de input antigo, pois ainda não sei usar o novo muito bem
        //Mas concordo que o novo seria bemmm melhor e mais performático

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space) && _checkIfPlayerWithinArea.IsInArea) {
                _puzzleManager.CheckIfInputObjIsRight(gameObject);
            }
        }
    }
}