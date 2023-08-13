using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLaserAI : MonoBehaviour
{

    PlayerManager player;
    public int runSpeed;
    float distance;
    public Stat range;

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    private LineRenderer lineRenderer;

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
        lineRenderer = GetComponent<LineRenderer>();
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
                    lineRenderer.enabled = false;
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



            lineRenderer.enabled = true;

            MakeALine(this.transform.position + temp, target.position);
            target.transform.gameObject.GetComponent<CharacterStats>().TakeDamage(10);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void MakeALine(Vector3 pos1, Vector3 pos2)
    {
        lineRenderer.SetPosition(0, pos1);
        lineRenderer.SetPosition(1, pos2);
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
