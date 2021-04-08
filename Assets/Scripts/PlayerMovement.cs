using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private float _jumpForce;

    private bool _isJumpKeyDown;

    private void Update()
    {
        _isJumpKeyDown = Input.GetKey(KeyCode.Space);
        Direction = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Jump()
    {
        if (_groundChecker.IsGrounded && _isJumpKeyDown)
        {
            Rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}
