using UnityEngine;

namespace Player.Player_Collisions{
    public class PlayerKeyCollision : BaseCollision{
        private AudioSource _audioSource;
        private Collider2D _collider2D;

        private void Start() {
            _audioSource = GetComponent<AudioSource>();
        }

        protected override void defaultMethod(Collision2D other) {
            PlayerKeyInventory.AddOneKey();

            _collider2D = other.gameObject.GetComponent<Collider2D>();
            _audioSource.Play();
            _collider2D.enabled = false;
            Destroy(other.gameObject, 5f);

        }

        protected override void OnDisable() {
            var numberOfKeysEnable = GameObject.FindGameObjectsWithTag(tag).Length;
            
            if (numberOfKeysEnable < 1) {
                base.OnDisable();
            }
        }
    }
}