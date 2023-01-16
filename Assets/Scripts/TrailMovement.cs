using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrailMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Rigidbody trailRigidBody;

    // Start is called before the first frame update
    void Awake()
    {
        trailRigidBody = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        NavMeshHit closestHit;
        if(NavMesh.SamplePosition(transform.position,out closestHit, 500f, NavMesh.AllAreas))
        {
            transform.position = closestHit.position;
            navMeshAgent.enabled = true;
        }
    }

    private void SetPosition(Transform target)
    {
        transform.position = target.position;
    }

    private void SetDestination(Transform destination)
    {
        //navMeshAgent.SetDestination(destination.position);
        transform.LookAt(destination);
        trailRigidBody.AddForce(Vector3.forward * 100);

    }

    public void DrawPath(Transform starting, Transform ending)
    {
        //SetPosition(starting);
        SetDestination(ending);
    }
}

