using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            other.transform.gameObject.GetComponent<CharacterStats>().TakeDamage(100);
            Destroy(this.transform.gameObject);
        }
        if (other.transform.gameObject.tag == "Wall" || other.transform.gameObject.tag == "Ground")
            Destroy(this.transform.gameObject);


    }
}
