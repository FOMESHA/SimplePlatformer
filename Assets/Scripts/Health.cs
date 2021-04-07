using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private HeartBox _heartBox;
    [SerializeField] private CoinsSpawner _coinsSpawner;

    public void TakeDamage()
    {
        _coinsSpawner.SpawnCoins();
        Destroy(gameObject);
    }
}
