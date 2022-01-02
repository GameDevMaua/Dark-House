using UnityEngine;

namespace Player.Player_Collisions{
    public class PlayerKeyCollision : BaseCollision{
        private AudioSource _audioSource;
        private Collider2D _collider2D;
        private SpriteRenderer _spriteRenderer;

        [SerializeField] private AudioClip[] _audioClipsArray;
        
        private void Start() {
            _audioSource = GetComponent<AudioSource>();
            
            var position = transform.position;
            position = new Vector3(position.x, position.y, 0f);
            
            transform.position = position;

            _audioSource.clip = _audioClipsArray[0];
            _audioSource.Play();
        }

        protected override void defaultMethod(Collision2D other) {
            PlayerKeyInventory.AddOneKey();
            ChangeAudioWhenCollide(other);
            DeactivateColliderAndSpriteRenderer(other);

            print($"Nós temos {PlayerKeyInventory.KeyCount} chaves");
        }

        private void DeactivateColliderAndSpriteRenderer(Collision2D other) {
            _collider2D = other.gameObject.GetComponent<Collider2D>();
            _spriteRenderer = other.gameObject.GetComponent<SpriteRenderer>();
            _collider2D.enabled = false;
            _spriteRenderer.enabled = false;
        }

        private void ChangeAudioWhenCollide(Collision2D other) {
            var audioSource = other.gameObject.GetComponent<AudioSource>();
            audioSource.Stop();
            audioSource.loop = false;
            audioSource.clip = _audioClipsArray[1];
            audioSource.spatialBlend = 0f;
            audioSource.Play();
        }

        protected override void OnDisable() {
            var numberOfKeysEnable = GameObject.FindGameObjectsWithTag(tag).Length;
            
            if (numberOfKeysEnable < 1) {
                base.OnDisable();
            }
        }
    }
}