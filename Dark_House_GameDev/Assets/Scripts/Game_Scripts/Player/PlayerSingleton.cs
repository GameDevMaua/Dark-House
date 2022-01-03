using Core;
using UnityEngine;

namespace Player{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerSingleton : Singleton<PlayerSingleton>{
        private Rigidbody2D _rigidbody2D;
        private float _horizontalAxisInput;
        private float _verticalAxisInput;

        [SerializeField] private float _movingVelocity = 4f;


        private void Start() {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }


        private void Update() {
            _horizontalAxisInput = Input.GetAxisRaw("Horizontal");
            _verticalAxisInput   = Input.GetAxisRaw("Vertical");
        }

        private void FixedUpdate() {
            _rigidbody2D.velocity = Vector2.ClampMagnitude(new Vector2(_horizontalAxisInput, _verticalAxisInput) * _movingVelocity, _movingVelocity);
        }
        
        public float MovingVelocity => _movingVelocity;

        public void SetMovingVeloctyToZero() {
            _movingVelocity = 0f;
        }

    }
}