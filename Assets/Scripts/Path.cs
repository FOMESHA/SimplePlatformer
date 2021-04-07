using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    private Waypoint[] _waypoints;
    private int _currentWaypointNumber = 0;

    private void Awake()
    {
        _waypoints = GetComponentsInChildren<Waypoint>();
    }

    public Waypoint GetNextWaypoint()
    {
        if (_currentWaypointNumber == _waypoints.Length)
        {
            _currentWaypointNumber = 0;
        }
        return _waypoints[_currentWaypointNumber++];
    }

}
