using System;
using UnityEngine;

public class PlayerSingleton2 : MonoBehaviour{
    private float _horizontalAxisInput;
    private float _verticalAxisInput;
    private Transform _playerTransform;
    private Rigidbody2D _rigidbody2D;
    
    [SerializeField] private float _movingVelocity;


    private void Start() {
        _playerTransform = GetComponent<Transform>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        RotatePlayer();
        MovePlayerFowards();
    }

    private void MovePlayerFowards() {

        if (Input.GetAxisRaw("Vertical") == 1) {
            
            _rigidbody2D.velocity = transform.up * _movingVelocity;
            
        }
        else {
            _rigidbody2D.velocity = Vector2.zero;
            
        }
    }

    private void RotatePlayer() {
        _horizontalAxisInput = Input.GetAxisRaw("Horizontal");
            
        var rot = Quaternion.Euler(0, 0, _verticalAxisInput * 90  + _playerTransform.eulerAngles.z);

        _playerTransform.rotation = rot;

    }
    
}
