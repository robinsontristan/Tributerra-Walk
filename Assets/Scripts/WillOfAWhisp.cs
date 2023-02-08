using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class WillOfAWhisp : MonoBehaviour
{
    public float travelDuration = 5f;
    public float waitTime = 1f;
    public float speed = 1f;
    public bool startPath = false;
    public int targetWaypointIndex = 0;
    public Action<Vector3> OnEndReached;
    void Start()
    {

        //For testing...remove this "StartPath" line when building to device.
        //startPath = true;
        //StartPath();

    }

    public void StartPath()
    {
       // StartCoroutine(FollowPath(waypoints, startPath));
    }
    private IEnumerator FollowPath(Vector3[] wayPoints, bool start)
    {
        //transform.position = wayPoints[0];

        Vector3 targetWaypoint = wayPoints[targetWaypointIndex + 1];
        while (start)
        {
            transform.LookAt(targetWaypoint);
            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
            if (transform.position == targetWaypoint)
            {
                targetWaypointIndex = (targetWaypointIndex + 1);
                targetWaypoint = wayPoints[targetWaypointIndex];

                if (targetWaypointIndex >= wayPoints.Length - 1)
                {
                    startPath = false;
                    start = startPath;
                    OnEndReached?.Invoke(targetWaypoint);
                    yield break;
                }

                yield return new WaitForSeconds(waitTime);
                start = false;

            }

            yield return null;
        }
    }

    public void StartTravel(Vector3 startPosition, Vector3 endPosition)
    {
        StartCoroutine(Travel(startPosition, endPosition));
        transform.LookAt(endPosition);

    }

    private IEnumerator Travel(Vector3 startPosition, Vector3 endPosition)
    {
        float elapsedTime = 0.0f;
        while(elapsedTime <= travelDuration)
        {
            elapsedTime += Time.deltaTime;
            Vector3 lerpPosition = Vector3.Lerp(startPosition, endPosition, elapsedTime / travelDuration);
            transform.position = lerpPosition;
            yield return new WaitForEndOfFrame();
        }

    }
}
