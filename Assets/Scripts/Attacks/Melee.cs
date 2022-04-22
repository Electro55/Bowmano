using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : Attack
{
    public override void DoAttack(PlayerManager player, Enemy enemy)
    {
        player.DealDamage(enemy);
    }
}
