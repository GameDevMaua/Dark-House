using System;
using System.Collections;
using System.Collections.Generic;
using Audio_Guides.AudioHandlers;
using UnityEngine;

public class BasicMoviment : MonoBehaviour
{
    [SerializeField]private float speed;

    [SerializeField] public Vector2 direction;
    [SerializeField] private Vector2 deltaPosition;

    [SerializeField] private FootControl _footControl;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    Vector2 lastFramePosition;

    // Start is called before the first frame update
    void Start()
    {
        _footControl = GetComponent<FootControl>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
        lastFramePosition = (Vector2)transform.position;
        // var position = lastFramePosition + direction * (Time.deltaTime * speed);
        // transform.Translate( direction * (Time.deltaTime * speed));

        
    }

    private void LateUpdate()
    {
        deltaPosition = _rigidbody2D.position - lastFramePosition;
        
        print(deltaPosition.magnitude);
        _footControl.isMoving = direction != Vector2.zero && deltaPosition.magnitude>0.01f;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        print(deltaPosition.magnitude);

    }

    // Update is called once per frame
    void Update()
    {
        var v = Input.GetAxis("Vertical");
        var h = Input.GetAxis("Horizontal");
        direction.x = h;
        direction.y = v;
        direction.Normalize();
        _rigidbody2D.velocity = direction * speed;

        
        
    }
}
