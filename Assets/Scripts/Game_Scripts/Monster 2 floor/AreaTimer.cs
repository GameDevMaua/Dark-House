using System;
using Events;
using UnityEngine;

namespace DefaultNamespace.Monster_2_floor{
    [RequireComponent(typeof(CheckIfPlayerWithinArea))]
    public class AreaTimer : MonoBehaviour{
        [SerializeField] private float maximumTimer;
        [SerializeField] private float currentTimer;
        
        private bool _isOnArea;
        private int _audioListLenght;
        private bool _timerIsRunning;
        private GhostAudioHandler _ghostAudioHandler;
        private CheckIfPlayerWithinArea _checkIfPlayerWithinArea;
        
        public TimerFractionHandler TimerFractionHandler = new TimerFractionHandler();
        public event Action TimerMaxEvent;
        public event Action TimerInitializedEvent;

        
        private void Start() {
            _checkIfPlayerWithinArea = GetComponent<CheckIfPlayerWithinArea>();
            _ghostAudioHandler = GetComponent<GhostAudioHandler>();
            _checkIfPlayerWithinArea.PlayerEnteredAreaEvent += OnPlayerEnteredArea;
            _checkIfPlayerWithinArea.PlayerLeftAreaEvent += OnPlayerLeftArea;
        }

        private void OnPlayerLeftArea() {
            _isOnArea = false;
        }

        private void OnPlayerEnteredArea() {
            _isOnArea = true;
            TimerFractionHandler.Set(_ghostAudioHandler.AudioListLength, maximumTimer);
        }

        private void Update() {

            if (_isOnArea) {
                currentTimer += Time.deltaTime;
            }
            else {
                currentTimer -= Time.deltaTime;
            }
            currentTimer = Mathf.Clamp(currentTimer, 0, maximumTimer);

            if(_isOnArea)
                TimerFractionHandler.UpdateNotUnity(currentTimer);

            if(currentTimer == 0)
                TimerInitializedEvent?.Invoke();
            else if(currentTimer == maximumTimer){
                TimerMaxEvent?.Invoke();
                EventManager.InvokeOnPlayerDeath();
            }
        }
    }
}
