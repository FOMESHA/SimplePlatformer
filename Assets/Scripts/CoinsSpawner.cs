using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private int _minCoinsCount;
    [SerializeField] private int _maxCoinsCount;

    private int _coinsCount;
    private List<Coin> _coins = new List<Coin>();

    private void Start()
    {
        _coinsCount = Random.Range(_minCoinsCount, _maxCoinsCount);
        GenerateCoins();
    }

    private void GenerateCoins()
    {
        for (int i = 0; i < _coinsCount; i++)
        {
            _coins.Add(Instantiate(_coinPrefab, transform.position, Quaternion.identity, transform));
        }
    }

    public void SpawnCoins()
    {
        foreach(Coin coin in _coins)
        {
            coin.gameObject.SetActive(true);
        }
    }
}
