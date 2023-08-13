using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRangedAI : MonoBehaviour
{
    PlayerManager player;
    public int runSpeed;
    float distance;
    public Stat range;

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    CharacterStats characterStats;
    Transform target;
    NavMeshAgent agent;
    public GameObject projectile;

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
            RaycastHit hit;
            var rayDirection = target.position - transform.position;

            if (Physics.Raycast(this.transform.position, rayDirection, out hit))
            {
                agent.isStopped = false;

                if (range.GetValue() >= distance && hit.transform.gameObject.layer == LayerMask.NameToLayer("Player"))
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
        }
        else
            agent.isStopped = true;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = lookRotation;
    }

    private void Attack()
    {

        if (!alreadyAttacked)
        {
            Vector3 temp = new Vector3(0, 4, 0);

            Rigidbody rb = Instantiate(projectile,
                            transform.position + temp,
                            Quaternion.identity).GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.AddForce(transform.forward * 2000);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
