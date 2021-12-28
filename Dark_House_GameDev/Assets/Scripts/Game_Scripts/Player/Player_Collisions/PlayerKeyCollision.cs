using UnityEngine;

namespace Player.Player_Collisions{
    public class PlayerKeyCollision : BaseCollision{
        private AudioSource _audioSource;
        private Collider2D _collider2D;
        private SpriteRenderer _spriteRenderer;

        private void Start() {
            _audioSource = GetComponent<AudioSource>();
            
            var position = transform.position;
            position = new Vector3(position.x, position.y, 0f);
            
            transform.position = position;
        }

        protected override void defaultMethod(Collision2D other) {
            PlayerKeyInventory.AddOneKey();

            _collider2D = other.gameObject.GetComponent<Collider2D>();
            _spriteRenderer = other.gameObject.GetComponent<SpriteRenderer>();
            
            _audioSource.Play();
            
            _collider2D.enabled = false;
            _spriteRenderer.enabled = false;
            
            print("Nós temos " +PlayerKeyInventory.KeyCount);

        }

        protected override void OnDisable() {
            var numberOfKeysEnable = GameObject.FindGameObjectsWithTag(tag).Length;
            
            if (numberOfKeysEnable < 1) {
                base.OnDisable();
            }
        }
    }
}