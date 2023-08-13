using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    public float Cooldown;
    private float currentCooldown;

    public virtual void PerformAttack(PlayerManager player, Enemy enemy)
    {
        if (currentCooldown <= 0)
        {
            DoAttack(player, enemy);
            currentCooldown = Cooldown;
        } else
        {
            currentCooldown -= Time.deltaTime;
        }

    }

    public abstract void DoAttack(PlayerManager player, Enemy enemy);
}
