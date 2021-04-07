using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _arrivalDistance;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Path _path;

    private Rigidbody2D _rigidbody2D;
    private Waypoint _currentWaypoint;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _currentWaypoint = _path.GetNextWaypoint();
    }

    private void FixedUpdate()
    {
        MoveToWaypoint();
    }

    private void MoveToWaypoint()
    {
        float distance = Mathf.Abs(_currentWaypoint.transform.position.x - transform.position.x);
        float direction = Mathf.Sign(_currentWaypoint.transform.position.x - transform.position.x);
        if (distance < _arrivalDistance)
        {
            _currentWaypoint = _path.GetNextWaypoint();
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(_movementSpeed * direction, _rigidbody2D.velocity.y);
        }
    }
}
