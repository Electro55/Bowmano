using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRangedAI : MonoBehaviour
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

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
