using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : Health
{
    [SerializeField] private CoinsSpawner _coinsSpawner;
    [SerializeField] private UnityEvent _onDie;

    protected override void Die()
    {
        _onDie.Invoke();
        _coinsSpawner.SpawnCoins();
        base.Die();
    }
}
