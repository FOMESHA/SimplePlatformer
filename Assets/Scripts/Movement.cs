using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private float _jumpForce;

    private float _direction;
    private Rigidbody2D _rigidbody2D;
    private bool _isJumpKeyDown;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _isJumpKeyDown = Input.GetKey(KeyCode.Space);
        _direction = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(_movementSpeed * _direction, _rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        if (_groundChecker.IsGrounded && _isJumpKeyDown)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

}
