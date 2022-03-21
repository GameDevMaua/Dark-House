using System;
using Events;
using UnityEngine;

namespace DefaultNamespace.Monster_2_floor{
    [RequireComponent(typeof(CheckIfPlayerWithinArea))]
    public class AreaTimer : MonoBehaviour{
        [SerializeField] private float _maximumTimer;
    
        [SerializeField] private float _currentTimer;
        private int _audioListLenght;
        private bool _timerIsRunning;
        private CheckIfPlayerWithinArea _checkIfPlayerWithinArea;
        public TimerFractionHandler _timerFractionHandler = new TimerFractionHandler();

        private GhostAudioHandler _ghostAudioHandler;

        public event Action TimerMaxEvent;
        public event Action TimerInitializedEvent;

        private bool _isOnArea;
        
        private void Start() {
            _checkIfPlayerWithinArea = GetComponent<CheckIfPlayerWithinArea>();

            _checkIfPlayerWithinArea.PlayerEnteredAreaEvent += OnPlayerEnteredArea;
            _checkIfPlayerWithinArea.PlayerLeftAreaEvent += OnPlayerLeftArea;
            _ghostAudioHandler = GetComponent<GhostAudioHandler>();
        }

        private void OnPlayerLeftArea() {
            _isOnArea = false;
        }

        private void OnPlayerEnteredArea() {
            _isOnArea = true;
            _timerFractionHandler.Set(_ghostAudioHandler.AudioListLength, _maximumTimer);
        }

        private void Update() {

            if (_isOnArea) {
                _currentTimer += Time.deltaTime;
            }
            else {
                _currentTimer -= Time.deltaTime;
            }
            _currentTimer = Mathf.Clamp(_currentTimer, 0, _maximumTimer);

            if(_isOnArea)
                _timerFractionHandler.UpdateNotUnity(_currentTimer);

            if(_currentTimer == 0)
                TimerInitializedEvent?.Invoke();
            else if(_currentTimer == _maximumTimer){
                TimerMaxEvent?.Invoke();
                EventManager.InvokeOnPlayerDeath();
            }
        }
    }
}
