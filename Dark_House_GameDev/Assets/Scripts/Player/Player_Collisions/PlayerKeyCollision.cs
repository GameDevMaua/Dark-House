using UnityEngine;

namespace Player.Player_Collisions{
    public class PlayerKeyCollision : BaseCollision{
        protected override void defaultMethod(Collision2D other) {
            PlayerKeyInventory.AddOneKey();
            Destroy(other.gameObject);
        }

        protected override void OnDisable() {
            var numberOfKeysEnable = GameObject.FindGameObjectsWithTag(tag).Length;

            if (numberOfKeysEnable <= 1) {
                base.OnDisable();
            }
        }
    }
}