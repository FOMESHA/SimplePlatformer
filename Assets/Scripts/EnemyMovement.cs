using UnityEngine;

public class EnemyMovement : Movement
{
    [SerializeField] private float _arrivalDistance;
    [SerializeField] private Path _path;

    private Waypoint _currentWaypoint;

    private void Start()
    {
        _currentWaypoint = _path.GetNextWaypoint();
        IsFacingRight = Mathf.Sign(_currentWaypoint.transform.position.x - transform.position.x) > 0;
    }

    private void FixedUpdate()
    {
        MoveToWaypoint();
    }

    private void MoveToWaypoint()
    {
        Direction = Mathf.Sign(_currentWaypoint.transform.position.x - transform.position.x);
        float distance = Mathf.Abs(_currentWaypoint.transform.position.x - transform.position.x);
        if (distance < _arrivalDistance)
        {
            _currentWaypoint = _path.GetNextWaypoint();
        }
        else
        {
            Move();
        }
    }
}
