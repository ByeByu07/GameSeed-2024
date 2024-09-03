using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Troop : MonoBehaviour
{
    private NavMeshAgent agent;
    [HideInInspector] public Vector3 locationToPatrol;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SetDestination(Transform target)
    {
        agent.SetDestination(target.position);
    }

    public void SetDestination(Vector3 target)
    {
        agent.SetDestination(target);
    }

    public void SetPositionPatrol()
    {
        if(locationToPatrol != Vector3.zero)
        {
            SetDestination(locationToPatrol);
            return;
        }
    }

    public void SetPositionPatrol(Transform location)
    {
        locationToPatrol = location.position;
    }
}
