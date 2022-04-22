using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : Attack
{
    public Projectile projectilePrefab;

    public override void DoAttack(PlayerManager player, Enemy enemy)
    {
        Vector3 temp = new Vector3(0, 4, 0);

        transform.LookAt(player.transform.localPosition - temp);
        var proj = Instantiate(projectilePrefab,
                        transform.position + temp,
                        this.gameObject.transform.localRotation);
        //proj.Faction = Faction.Enemy;
        Rigidbody rb = proj.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddForce(transform.forward * 20, ForceMode.Impulse);
    }
}
