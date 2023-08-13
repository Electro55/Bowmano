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
        base.MaxHp = 1000;
        agent = GetComponent<NavMeshAgent>();
        IncreaseMaxHp(StatsManager.Instance.HP.FinalMult);
    }
}
