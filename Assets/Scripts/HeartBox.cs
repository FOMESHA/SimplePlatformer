using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HeartBox : MonoBehaviour
{
    private Health _health;

    private void Start()
    {
        _health = GetComponentInParent<Health>();
    }

    public void TakeDamage()
    {
        _health.TakeDamage();
    }
}
