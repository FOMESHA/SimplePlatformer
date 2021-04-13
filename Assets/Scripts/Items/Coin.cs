using System.Collections;
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
        StartCoroutine(ActivateCollectebleComponent());
        StartCoroutine(DestroyByTime());
    }

    private void AddStartImpulse()
    {
        _rigidbody2D.AddForce(new Vector2(Random.Range(-1f, 1f), 1f) * _spawnImpulseForce, ForceMode2D.Impulse);
    }

    private IEnumerator ActivateCollectebleComponent()
    {
        var waitForSeconds = new WaitForSeconds(_activateCollectableTime);
        yield return waitForSeconds;
        _collectableItem.SetActive(true);
        yield break;
    }

    private IEnumerator DestroyByTime()
    {
        var waitForSeconds = new WaitForSeconds(_timeToDestroy);
        yield return waitForSeconds;
        Destroy(gameObject);
        yield break;
    }
}
