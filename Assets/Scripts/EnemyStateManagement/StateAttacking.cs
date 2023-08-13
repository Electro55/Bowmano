using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAttacking : State
{
    private float currentPlayerDist;
    private Attack attack;


    private void Awake()
    {
        EnemyState = EnemyState.Attacking;
        attack = GetComponent<Attack>();
    }

    public override void InitState(PlayerManager player, Enemy enemy)
    {
        base.InitState(player, enemy);
        currentPlayerDist = GetDistanceToPlayer();
    }

    public override void Act()
    {
        //Debug.Log(currentPlayerDist);
        enemy.Animator.SetFloat("PlayerRange", currentPlayerDist);
        attack?.PerformAttack(player, enemy);
    }

    public override EnemyState TryToChangeState()
    {
        currentPlayerDist = GetDistanceToPlayer();

        if (currentPlayerDist > enemy.AttackRange)
        {
            return EnemyState.FollowingPlayer;
        }
        return EnemyState;
    }
}
