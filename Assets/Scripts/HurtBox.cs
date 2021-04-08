using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class HurtBox : MonoBehaviour
{
    [SerializeField] private float _takingDamageTime;

    private Health _health;
    private bool _isHurt;

    public bool IsHurt => _isHurt;

    private void Start()
    {
        _health = GetComponentInParent<Health>();
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
        _isHurt = true;
        StartCoroutine(TakeHitTimer());
    }

    private IEnumerator TakeHitTimer()
    {
        var waitForSeconds = new WaitForSeconds(_takingDamageTime);
        yield return waitForSeconds;
        _isHurt = false;
        yield break;
    }
}
