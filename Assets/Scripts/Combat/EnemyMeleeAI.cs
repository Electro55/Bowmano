using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMeleeAI : MonoBehaviour
{
    PlayerManager player;
    public int runSpeed;
    float distance;
    public Stat range;
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    Quaternion lookRotation;


    public ParticleSystem hitParticles;
    CharacterStats characterStats;
    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        characterStats = GetComponent<CharacterStats>();
        range = characterStats.range;
        target = player.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = runSpeed;
    }

    void Update()
    {
        if (target != null)
        {
            distance = Vector3.Distance(transform.position, target.position);

            agent.isStopped = false;

            if (range.GetValue() >= distance)
            {
                agent.isStopped = true;
                FaceTarget();
                Attack();
            }
            else
            {
                agent.speed = runSpeed;
                agent.SetDestination(target.position);
            }
        }
        else
            agent.isStopped = true;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = lookRotation;
    }

    private void Attack()
    {

        if (!alreadyAttacked)
        {

            Instantiate(hitParticles, this.transform.position, lookRotation);
            target.transform.gameObject.GetComponent<CharacterStats>().TakeDamage(10);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
