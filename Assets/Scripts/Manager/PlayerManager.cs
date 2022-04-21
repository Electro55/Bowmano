using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerManager : Unit
{
    private NavMeshAgent agent;

    public NavMeshAgent Agent => agent;

    protected override void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
    }
}
