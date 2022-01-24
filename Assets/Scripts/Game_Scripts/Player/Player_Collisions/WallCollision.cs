using Game_Scripts.Scriptable_Objects;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Player.Player_Collisions{
    public class WallCollision : BaseCollision{
        private Vector2 _colisionPoint1;
        private Vector2 _colisionPoint2;

        [SerializeField] private GameObject _wallAudioSourceGameObject;
        [SerializeField] private StringSoundDictionary _soundDictionary;
        [SerializeField] private Tilemap _wallsTilemap;
        [SerializeField] private AudioClip _defaultSound;
        private AudioSource _wallAudioSource;

        private void Start() {
            _wallAudioSource = _wallAudioSourceGameObject.GetComponent<AudioSource>();
        }

        
        protected override void defaultMethod(Collision2D other) {
            if(!_wallAudioSource.isPlaying) {
                // _SetAudioClipInAudioSource(other);
                _SetPositionInCollisionPoint(other);
                _wallAudioSource.Play();
            }
            
        }

        private void _SetAudioClipInAudioSource(Collision2D other) {
            var collisionPoint = _GetCollisionPoint(other);
            var collidedTilePosition = new Vector3Int(Mathf.RoundToInt(collisionPoint.x), Mathf.RoundToInt(collisionPoint.y), 0);

            var collidedTileName = _wallsTilemap.GetTile(collidedTilePosition).name;

            var newAudioClip = _defaultSound;

            if (_soundDictionary.dictionary.ContainsKey(collidedTileName))
                newAudioClip = _soundDictionary.dictionary[collidedTileName];

            _wallAudioSource.clip = newAudioClip;
        }
        
        private void _SetPositionInCollisionPoint(Collision2D other) {
            var colisionMiddlePoint = _GetCollisionPoint(other);

            _wallAudioSourceGameObject.transform.position = colisionMiddlePoint;
        }

        private Vector2 _GetCollisionPoint(Collision2D other) {
            _colisionPoint1 = other.GetContact(0).point;
            _colisionPoint2 = other.GetContact(1).point;

            var colisionMiddlePoint = (_colisionPoint1 + _colisionPoint2) / 2;
            return colisionMiddlePoint;
        }
    }
}