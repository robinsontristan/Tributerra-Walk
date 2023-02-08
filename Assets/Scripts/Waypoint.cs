using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    private Transform parentTransform;
    public WillOfAWhisp willOfAWhisp;
    public Action<Vector3> OnEndReached;


    public int WaypointIndex { get; private set; }

    public int? NextWaypointIndex
    { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < parentTransform.childCount; i++)
        {
            Transform child = parentTransform.GetChild(i);
            if(child ==this.transform)
            {
                WaypointIndex = i;
                NextWaypointIndex = i + 1;

                Player.Instance.PlayerWaypointIndex = WaypointIndex;

                if (NextWaypointIndex >= parentTransform.childCount)
                {
                    NextWaypointIndex = null;

                }
                Player.Instance.NextPlayerWaypointIndex = NextWaypointIndex;

            }

            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            DoTravel();
        }
    }

    public void DoTravel()
    {
        Player.Instance.PlayerWaypointIndex = WaypointIndex;

        if (!NextWaypointIndex.HasValue)
        {
            OnEndReached?.Invoke(WaypointPosition());
        }
        else
        {
            willOfAWhisp.StartTravel(WaypointPosition(), NextWaypointPosition());
        }

    }

    public Vector3 WaypointPosition()
    {
        return this.transform.position;
    }

    public Vector3 NextWaypointPosition()
    {
        if (NextWaypointIndex.HasValue)
        {
            var next = parentTransform.GetChild((int)NextWaypointIndex);
            return next.position;
        }
        else return default;
    }

}
