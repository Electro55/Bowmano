using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDying : State
{

    private void Awake()
    {
        EnemyState = EnemyState.Dying;
    }

    public override void InitState(PlayerManager player, Enemy enemy)
    {
        base.InitState(player, enemy);
        enemy.Agent.isStopped = true;
        enemy.Animator.SetTrigger("Died");
        EnemyCounter.Instance.RemoveEnemy(this.gameObject.GetComponent<Enemy>());
        Destroy(gameObject, 2f);
        enemy.GetComponentInChildren<Collider>().enabled = false;
    }


    public override void Act()
    {
        return;
    }

    public override EnemyState TryToChangeState()
    {
        return EnemyState.Dying;
    }

}
