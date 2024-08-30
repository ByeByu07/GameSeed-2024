using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public EnemyHealth enemyHealth;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float radius;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int damage;
    [SerializeField] private int attackSpeed;
    [SerializeField] private Transform seedDestination;

    void Start()
    {
        if (agent.isOnNavMesh)
        {
            SetDestionationToSeed();
        } 
    }
    public virtual void Update()
    {
        //throw new NotImplementedException();
    }

    public void SetDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    public void SetDestination(Transform destination)
    {
        agent.SetDestination(destination.position);
    }

    public void SetDestionationToSeed()
    {
        SetDestination(seedDestination);
    }
}
