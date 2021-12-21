using UnityEngine;

namespace Player.Player_Collisions{
    public class DoorCollision : BaseCollision{

        private int _numberOfKeysNeeded;

        private void Start() {
            var keysGameObjsArray = GameObject.FindGameObjectsWithTag("Key");

            _numberOfKeysNeeded = keysGameObjsArray.Length;
            
        }

        protected override void defaultMethod(Collision2D other) {
            if (PlayerKeyInventory.KeyCount >= _numberOfKeysNeeded) {
                print("Abre-te sésamo");
            }
            
        }
    }
}