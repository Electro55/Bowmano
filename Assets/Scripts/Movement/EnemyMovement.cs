using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public int runSpeed;

    public Stat range;

    CharacterStats characterStats;
    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        characterStats = GetComponent<CharacterStats>();
        range = characterStats.range;
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = runSpeed;
    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        agent.isStopped = false;

        if (range.GetValue() < distance)
        {

            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                // Attack target
                FaceTarget();
            }
        }
        else
        {
            agent.isStopped = true;
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
