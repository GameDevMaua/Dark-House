using System;
using System.Collections;
using DefaultNamespace.Monster_2_floor;
using Events;
using UnityEngine;

public class Ghost2Timer : MonoBehaviour{
    [SerializeField] private float _initialTimer;
    [SerializeField] private float _currentTimer; //deixei serializado apenas para facilitar o debug no inspetor
    private int _audioListLenght;
    private bool _timerIsRunning;

    public static event Action<int> CurrentTimerPartIsEvent; 

    private void Awake() {
        _currentTimer = _initialTimer;
    }

    private void Start() {
        _audioListLenght = GetComponent<GhostAudioHandler>().AudioListLength;
    }

    private void OnEnable() {
        CheckIfPlayerWithinArea.PlayerEnteredAreaEvent += StartTimerCoroutine;
        CheckIfPlayerWithinArea.PlayerLeftedAreaEvent += FinishTimerAndRestartIt;
    }

    private void OnDisable() {
        CheckIfPlayerWithinArea.PlayerEnteredAreaEvent -= StartTimerCoroutine;
        CheckIfPlayerWithinArea.PlayerLeftedAreaEvent -= FinishTimerAndRestartIt;
    }

    public void StartTimerCoroutine() {
        CurrentTimerPartIsEvent?.Invoke(0);
        _timerIsRunning = true;
        StartCoroutine(TimerCoroutine());
    }

    public void FinishTimerAndRestartIt() {        
        _timerIsRunning = false;
        StopCoroutine(TimerCoroutine());
        _currentTimer = _initialTimer;
    }

    private void CallEventsInEveryTimerPart() {
        var timerDividedIn = _initialTimer / _audioListLenght;
        var currentTimerIsDivisible = (_currentTimer % timerDividedIn) == 0 ;

        if (currentTimerIsDivisible && _currentTimer != 0) {
            var indexInAudioList = (int) (_currentTimer / timerDividedIn);
            
            CurrentTimerPartIsEvent?.Invoke(indexInAudioList);
        }
        
        else if(_currentTimer == 0)
            EventManager.InvokeOnPlayerDeath();
    }
    
    private IEnumerator TimerCoroutine() {
        while (_currentTimer > 0 && _timerIsRunning) {
            _currentTimer -= 0.5f;
            CallEventsInEveryTimerPart();
            yield return new WaitForSeconds(0.5f);
            
        }
    }
    
}