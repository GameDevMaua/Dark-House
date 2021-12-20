using UnityEngine;

namespace Player.Player_Colisions{
    public class WallColision : BaseColision{
        private Vector2 _colisionPoint1;
        private Vector2 _colisionPoint2;

        [SerializeField] private GameObject _wallAudioSourceGameObject;
        private AudioSource _wallAudioSource;

        private void Start() {
            
            _wallAudioSource = _wallAudioSourceGameObject.GetComponent<AudioSource>();
        }

        protected override void defaultMethod(Collision2D other) {
            _colisionPoint1 = other.GetContact(0).point;
            _colisionPoint2 = other.GetContact(1).point;

            var colisionMiddlePoint = (_colisionPoint1 + _colisionPoint2)/2;

            _wallAudioSourceGameObject.transform.position = colisionMiddlePoint;
         
            _wallAudioSource.Play();
        }
        
    }
}