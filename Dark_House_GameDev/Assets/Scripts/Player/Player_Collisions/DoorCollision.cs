using UnityEngine;

namespace Player.Player_Collisions{
    public class DoorCollision : BaseCollision{

        private int _numberOfKeysNeeded;

        private AudioSource _audioSource;

        [SerializeField]private AudioClip[] _audioClipsArray;

        private void Start() {
            var keysGameObjsArray = GameObject.FindGameObjectsWithTag("Key");

            _numberOfKeysNeeded = keysGameObjsArray.Length;

            _audioSource = GetComponent<AudioSource>();
            
            print("Precisam de "+_numberOfKeysNeeded);

        }

        protected override void defaultMethod(Collision2D other) {
            if (PlayerKeyInventory.KeyCount >= _numberOfKeysNeeded) {
                _audioSource.clip = _audioClipsArray[0];
                _audioSource.Play();
                print("Abre-te sésamo");
                
            }
            else if(!_audioSource.isPlaying) {
                _audioSource.clip = _audioClipsArray[1];
                _audioSource.Play();
            }
            
        }
    }
}