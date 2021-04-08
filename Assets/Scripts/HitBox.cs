using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitBox : MonoBehaviour, IGivingDamage
{
    [SerializeField] protected LayerMask EnemyHeartBox;
    [SerializeField] protected int Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckHeartBox(collision);
    }

    protected virtual void GiveDamage(Collider2D collision)
    {
        collision.GetComponent<HurtBox>().TakeDamage(Damage);
        Knockback knockback = collision.GetComponent<Knockback>();
        if (knockback != null)
        {
            float directionToEnemy = Mathf.Sign(collision.transform.position.x - gameObject.transform.position.x);
            knockback.AddImpulse(directionToEnemy);
        }
    }

    protected virtual void CheckHeartBox(Collider2D collision)
    {
        var collisionLayerMask = 1 << collision.gameObject.layer;
        if (EnemyHeartBox.value == collisionLayerMask)
        {
            GiveDamage(collision);
        }
    }
}
