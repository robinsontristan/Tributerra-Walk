using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointParent : MonoBehaviour
{

    public Transform waypointHolder;
    private Vector3[] waypoints;


    void Start()
    {
        waypoints = new Vector3[waypointHolder.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = waypointHolder.GetChild(i).position;
        }


    }

    private void OnDrawGizmosSelected()
    {
        Vector3 startPosition = waypointHolder.GetChild(0).position;
        Vector3 previousPosition = startPosition;
        foreach (Transform waypoint in waypointHolder)
        {
            Gizmos.DrawSphere(waypoint.position, 0.3f);
            Gizmos.DrawLine(previousPosition, waypoint.position);
            previousPosition = waypoint.position;

        }
    }
}
