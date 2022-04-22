using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class ShootingAI : MonoBehaviour
{

    public NavMeshAgent agent;
    private Unit target;

    List<Enemy> enemies;

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    [SerializeField]
    private Projectile projectile;


    private void Start()
    {
        enemies = EnemyCounter.Instance.enemies;
        timeBetweenAttacks *= (2 - StatsManager.Instance.AttackSpeed.FinalMult);
    }

    private void Update()
    {
        //print(enemies.Count);
        if (!this.transform.gameObject.GetComponent<PlayerMovement>().IsMoving && enemies.Count > 0)
            Attack();
    }

    private void Attack()
    {
        target = GetClosestEnemy();
        if (!alreadyAttacked)
        {
            Vector3 temp = new Vector3(0, 4, 0);

            transform.LookAt(target.transform.localPosition - temp);
            var proj = Instantiate(projectile,
                            transform.position + temp,
                            this.gameObject.transform.localRotation);
            proj.Damage = (int)(proj.Damage * StatsManager.Instance.Damage.FinalMult);
            Rigidbody rb = proj.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.AddForce(transform.forward * 20, ForceMode.Impulse);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    public Unit GetClosestEnemy()
    {
        if (enemies.Count > 0)
        {
            var ordered = EnemyCounter.Instance.enemies.OrderBy(enemy => Vector3.Distance(transform.position, enemy.transform.position));
            return ordered.First();
        }
        return null;
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
