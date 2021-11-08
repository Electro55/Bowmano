using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.gameObject.tag == "Zmrd")
        {
            Destroy(other.transform.gameObject);
            Destroy(this.transform.gameObject);
        }
        if (other.transform.gameObject.tag == "Wall")
            Destroy(this.transform.gameObject);


    }
}
