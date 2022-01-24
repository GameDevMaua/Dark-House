using System;
using Events;
using Game_Scripts.Scriptable_Objects;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Player.State_Machine{
    public class WalkingPlayerState : BasePlayerState{
        private AudioSource _audioSource;

        private StringSoundDictionary _soundDictionary;
        private Tilemap _tilemap;
        private AudioClip _defaultAudioClip;
        
        public event Action OnWalking;


        public override void OnStateEnter() {
            SubscribeOnGameOverEvent(EndGame);   
        }

        public override void OnStateExit() {
            UnsubscribeOnGameOverEvent(EndGame);
        }

        public override void executeState() {
            OnWalking?.Invoke();
            UpdateAudioClipOnAudioSource();
            
            if(!_audioSource.isPlaying)
                _audioSource.PlayDelayed(0.5f);
            
            if (_playerRigidbody.velocity.magnitude <= _playerSingleton.MovingVelocity * 0.20f) {
                PlayerStateMachine.ChangeCurrentState(PlayerStateMachine.IdlePlayerState);
            }
        }

        private void UpdateAudioClipOnAudioSource() {
            var playerPosition = _playerSingleton.transform.position;
            var currentTile = _tilemap.GetTile(new Vector3Int(Mathf.RoundToInt(playerPosition.x), Mathf.RoundToInt(playerPosition.y),
                Mathf.RoundToInt(playerPosition.z)));

            var newClip = _defaultAudioClip;

            if (currentTile){
                if(_soundDictionary.dictionary.ContainsKey(currentTile.name)) {
                    newClip = _soundDictionary.dictionary[currentTile.name];
                }
            }
            _audioSource.clip = newClip;

        }
        
        
        private void SubscribeOnGameOverEvent(Action function) {

            EventManager.OnGameOver += function;
        }
        private void UnsubscribeOnGameOverEvent(Action function) {

            EventManager.OnGameOver -= function;
        }
        
        public void EndGame() {
            PlayerStateMachine.ChangeCurrentState(PlayerStateMachine.DeadState);
        }

        public WalkingPlayerState(PlayerStateMachineManager playerStateMachineManager, AudioSource audioSource, Tilemap tilemap, StringSoundDictionary soundDictionary,
            AudioClip defaultAudioClip) : base(playerStateMachineManager) {
            _audioSource = audioSource;
            _tilemap = tilemap;
            _soundDictionary = soundDictionary;
            _defaultAudioClip = defaultAudioClip;
        }
    }
}