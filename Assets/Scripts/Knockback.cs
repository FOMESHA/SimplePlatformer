using UnityEngine;

public class Knockback : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _knockbackForce;

    public void AddImpulse(float direction)
    {
        Vector2 forceDirection = new Vector2(direction, 1f);
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.AddForce(forceDirection * _knockbackForce, ForceMode2D.Impulse);
    }

}
