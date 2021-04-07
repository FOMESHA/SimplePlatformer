using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _spawnImpulseForce;
    [SerializeField] private GameObject _collectableItem;
    [SerializeField] private float _activateCollectableTime;
    [SerializeField] private float _timeToDestroy;

    private void OnEnable()
    {
        gameObject.transform.parent = null;
        AddStartImpulse();
        StartCoroutine(ActivateCollecteble());
        StartCoroutine(Destroyer());
    }

    private void AddStartImpulse()
    {
        _rigidbody2D.AddForce(new Vector2(Random.Range(-1f, 1f), 1f) * _spawnImpulseForce, ForceMode2D.Impulse);
    }

    IEnumerator ActivateCollecteble()
    {
        var waitForSeconds = new WaitForSeconds(_activateCollectableTime);
        yield return waitForSeconds;
        _collectableItem.SetActive(true);
        yield break;
    }

    IEnumerator Destroyer()
    {
        var waitForSeconds = new WaitForSeconds(_timeToDestroy);
        yield return waitForSeconds;
        Destroy(gameObject);
        yield break;
    }
}
