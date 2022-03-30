using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class ShootingAI : MonoBehaviour
{

    public NavMeshAgent agent;
    public LayerMask whatIsEnemy;
    public Transform enemy;
    public int forceForward;

    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    CharacterStats characterStats;
    List<Collider> colliders;

    private void Start()
    {
        characterStats = GetComponent<CharacterStats>();
        colliders = Physics.OverlapSphere(transform.position, 1000, whatIsEnemy).ToList();
        colliders = colliders.OrderByDescending(collider => collider != null ?
                                                Vector3.Distance(collider.gameObject.transform.position,
                                                transform.position) : int.MaxValue).ToList();
    }

    private void Update()
    {
        if (!this.transform.gameObject.GetComponent<PlayerMovement>().IsMoving) Attack();
        if (colliders.Count != 0)
        {
            colliders = colliders.OrderByDescending(collider => collider != null ?
                                                    Vector3.Distance(collider.transform.position,
                                                    transform.position) : int.MaxValue).ToList();
        }

    }

    private void Attack()
    {

        if (!alreadyAttacked)
        {
            if (colliders.Count != 0 && colliders.Last() != null)
            {
                Vector3 direction = new Vector3(colliders.Last().transform.position.x,
                                                colliders.Last().transform.position.y,
                                                colliders.Last().transform.position.x).normalized;

                transform.LookAt(colliders.Last().transform);

                Vector3 temp = new Vector3(0, 4, 0);

                Rigidbody rb = Instantiate(projectile,
                                transform.position + temp,
                                this.gameObject.transform.localRotation).GetComponent<Rigidbody>();
                rb.useGravity = false;
                rb.AddForce(transform.forward * 2000);
                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }


        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
