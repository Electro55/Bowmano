using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public string tag;

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.gameObject.layer == LayerMask.NameToLayer(tag) && other.transform.gameObject != null)
        {
            other.transform.gameObject.GetComponent<CharacterStats>().TakeDamage(25);
            Destroy(this.transform.gameObject);
        }
        if (other.transform.gameObject.tag == "Wall" || other.transform.gameObject.tag == "Ground")
            Destroy(this.transform.gameObject);


    }
}
