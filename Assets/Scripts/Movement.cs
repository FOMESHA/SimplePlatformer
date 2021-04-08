using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] protected float MovementSpeed;

    protected float Direction;
    protected Rigidbody2D Rigidbody2D;
    protected HurtBox HurtBox;
    protected bool IsFacingRight = true;

    private void Awake()
    {
        InitializeComponents();
    }

    protected void InitializeComponents()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        HurtBox = GetComponentInChildren<HurtBox>();
    }

    protected void Move()
    {
        if (!HurtBox.IsHurt)
        {
            Rigidbody2D.velocity = new Vector2(MovementSpeed * Direction, Rigidbody2D.velocity.y);
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        if (Rigidbody2D.velocity.x > 0 && !IsFacingRight || Rigidbody2D.velocity.x < 0 && IsFacingRight)
        {
            RotateSprite();
        }
    }

    private void RotateSprite()
    {
        transform.Rotate(new Vector2(0f, 180f));
        IsFacingRight = !IsFacingRight;
    }
}
