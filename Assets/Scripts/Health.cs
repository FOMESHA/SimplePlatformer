using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _healthPoints;

    public virtual void TakeDamage(int damage)
    {
        _healthPoints -= damage;
        if (_healthPoints <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
