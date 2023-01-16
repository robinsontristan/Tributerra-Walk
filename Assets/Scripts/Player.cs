using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance
    {
        get;
        private set;
    }

    public int PlayerWaypointIndex
    {
        get;
        set;
    }

    public WillOfAWhisp whisp;

    void Awake()
    {
        if(Instance != null)
        {
            throw new System.Exception($"There are two players in the scene! {Instance} :: {this}");
        }

        Instance = this;
    }

    public Vector3 PlayerPosition()
    {
        return transform.localPosition;
    }

    public void StartPath(Vector3 startPosition, Vector3 endPosition)
    {
        whisp.StartTravel(startPosition, endPosition);
    }
}
