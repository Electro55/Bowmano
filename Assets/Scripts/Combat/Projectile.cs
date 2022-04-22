using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
     [SerializeField]
    private Faction faction = Faction.Friendly;

    public Faction Faction
    {
        get { return faction; }
        set { faction = value; }
    }

    private int damage = 50;
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }


    private void OnCollisionEnter(Collision collision)
    {
        var unit = collision.collider.GetComponent<Unit>();
        if (unit)
        {
            if (unit.Faction != faction)
            {
                unit.DealDamage(this);
                Destroy(gameObject);
            }
        }
        if (collision.transform.gameObject.tag == "Wall")
            Destroy(gameObject);
    }
}
