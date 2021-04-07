using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Stomper : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyHeartBox;
    [SerializeField] private float _bounForce;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponentInParent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collisionLayerMask = 1 << collision.gameObject.layer;
        if (_enemyHeartBox.value == collisionLayerMask)
        {
            collision.GetComponent<HeartBox>().TakeDamage();
            _rigidbody2D.AddForce(Vector2.up * _bounForce, ForceMode2D.Impulse);
        }
    }
}
