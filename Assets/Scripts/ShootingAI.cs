using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootingAI : MonoBehaviour
{
    public int Radius;
    public NavMeshAgent agent;
    public LayerMask whatIsEnemy;
    public Transform enemy;
    public int forceUp, forceForward;

    public bool playerInAttackRange;

    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;


    Collider[] colliders;

    private void Update()
    {
        colliders = Physics.OverlapSphere(transform.position, Radius, whatIsEnemy);
        playerInAttackRange = Physics.CheckSphere(transform.position, Radius, whatIsEnemy);
        if (playerInAttackRange && !this.transform.gameObject.GetComponent<PlayerMovement>().IsMoving) Attack();

    }

    private void Attack()
    {

        if (!alreadyAttacked)
        {
            if (colliders[0] != null)
            {

                Vector3 direction = new Vector3(colliders[0].transform.position.x, colliders[0].transform.position.y, colliders[0].transform.position.x).normalized;
                //float targetAngle = Mathf.Atan2(direction.y, direction.y) * Mathf.Rad2Deg;
                float targetAngle = Mathf.Atan2(direction.y, -direction.x) * Mathf.Rad2Deg;
                transform.GetChild(0).transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);


                transform.LookAt(colliders[0].transform);

                Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * forceForward, ForceMode.Impulse);
                rb.AddForce(transform.up * forceUp, ForceMode.Impulse);
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
