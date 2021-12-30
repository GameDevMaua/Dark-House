using System;
using Game_Scripts.Monster;
using Game_Scripts.Monster.State_Machine;
using UnityEngine;

namespace Player.Player_Collisions{
    public class DoorCollision : BaseCollision{

        private int _numberOfKeysNeeded;
        private AudioSource _audioSource;
        public event Action OnWinGame;
        
        [SerializeField] private AudioClip[] _audioClipsArray;

        private void Start() {
            var keysGameObjsArray = GameObject.FindGameObjectsWithTag("Key");

            _numberOfKeysNeeded = keysGameObjsArray.Length;

            _audioSource = GetComponent<AudioSource>();
            
            print($"Precisa de {_numberOfKeysNeeded} chaves");

        }

        protected override void defaultMethod(Collision2D other) {
            if (PlayerKeyInventory.KeyCount >= _numberOfKeysNeeded && !_audioSource.isPlaying) {
                _audioSource.clip = _audioClipsArray[0];
                _audioSource.Play();
                OnWinGame?.Invoke();

                var monsterStatemachine = MonsterSingleton.Instance.GetComponent<MonsterStateMachineManager>();
                monsterStatemachine.ChangeCurrentState(monsterStatemachine.NullState);

            }
            else if(!_audioSource.isPlaying) {
                _audioSource.clip = _audioClipsArray[1];
                _audioSource.Play();
            }
            
        }
    }
}