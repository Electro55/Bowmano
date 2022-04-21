using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAttacking : State
{
    private float currentPlayerDist;

    private void Awake()
    {
        EnemyState = EnemyState.Attacking;
    }

    public override void InitState(PlayerManager player, Enemy enemy)
    {
        base.InitState(player, enemy);
        currentPlayerDist = GetDistanceToPlayer();
    }

    public override void Act()
    {
        Debug.Log(currentPlayerDist);
        enemy.Animator.SetFloat("PlayerRange", currentPlayerDist);

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
