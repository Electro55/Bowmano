using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class ShootingAI : MonoBehaviour
{

    public int Radius;
    public NavMeshAgent agent;
    public LayerMask whatIsEnemy;
    public Transform enemy;
    public int forceUp, forceForward;

    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    List<Collider> colliders;

    private void Start()
    {
        colliders = Physics.OverlapSphere(transform.position, Radius, whatIsEnemy).ToList();

    }

    private void Update()
    {

        if (!this.transform.gameObject.GetComponent<PlayerMovement>().IsMoving) Attack();
        if (colliders.Count != 0)
        {
            colliders = colliders.OrderByDescending(collider => Vector3.Distance(collider.transform.position, transform.position)).ToList();
        }
    }

    private void Attack()
    {

        if (!alreadyAttacked)
        {
            if (colliders.Count != 0 && colliders.Last() != null)
            {
                Vector3 direction = new Vector3(colliders.Last().transform.position.x, colliders.Last().transform.position.y, colliders.Last().transform.position.x).normalized;
                //float targetAngle = Mathf.Atan2(direction.y, direction.y) * Mathf.Rad2Deg;
                float targetAngle = Mathf.Atan2(direction.y, -direction.x) * Mathf.Rad2Deg;
                transform.GetChild(0).transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

                transform.LookAt(colliders.Last().transform);

                Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * forceForward, ForceMode.Impulse);
                rb.AddForce(transform.up * forceUp, ForceMode.Impulse);
                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }

            if (colliders.Last() == null)
            {
                colliders.Remove(colliders.Last());
            }

        }


        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
