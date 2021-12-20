using Core;
using UnityEngine;

namespace Player{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerSingleton2 : Singleton<PlayerSingleton2>{
        private float _horizontalAxisInput;
        private float _verticalAxisInput;
        private Transform _playerTransform;
        private Rigidbody2D _rigidbody2D;

        [SerializeField] private float _movingVelocity = 4f;


        private void Start() {
            _playerTransform = GetComponent<Transform>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update() {
            RotatePlayer();
            MovePlayerFowards();
        }

        private void MovePlayerFowards() {

            if (Input.GetAxisRaw("Vertical") == 1)
                _rigidbody2D.velocity = transform.up * _movingVelocity;
        
            else 
                _rigidbody2D.velocity = Vector2.zero;
            
        
        }

        private void RotatePlayer() {
            _horizontalAxisInput = Input.GetAxisRaw("Horizontal");
            
            if(Input.GetButtonDown("Horizontal"))
                _playerTransform.Rotate(Vector3.back * 90 * _horizontalAxisInput);

        }
    
    }
}
