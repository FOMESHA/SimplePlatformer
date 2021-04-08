using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : HitBox, IGivingDamage
{

    [SerializeField] private float _bounForce;
    [SerializeField] private GameObject _selfHeartBox;
    [SerializeField] private float _invulnerabilityTime;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponentInParent<Rigidbody2D>();
    }

    protected override void GiveDamage(Collider2D collision)
    {
        Vector2 normal = (collision.bounds.center - transform.position).normalized;
        if (Vector2.Dot(normal, Vector2.up) * -1 >= 0.7f)
        {
            StartCoroutine(OffHeartBox());
            base.GiveDamage(collision);
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(Vector2.up * _bounForce, ForceMode2D.Impulse);
        }
    }

    IEnumerator OffHeartBox()
    {
        var waitForSeconds = new WaitForSeconds(_invulnerabilityTime);
        _selfHeartBox.SetActive(false);
        yield return waitForSeconds;
        _selfHeartBox.SetActive(true);
        yield break;
    }
}
