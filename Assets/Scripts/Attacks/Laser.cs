using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : Attack
{
    LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public override void DoAttack(PlayerManager player, Enemy enemy)
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPositions(new Vector3[] { player.transform.position, enemy.transform.position });
        lineRenderer.enabled = true;

        player.DealDamage(enemy);

        Invoke("DisableLine", 0.2f);
    }

    private void DisableLine()
    {
        lineRenderer.enabled = false;
    }
    
}
