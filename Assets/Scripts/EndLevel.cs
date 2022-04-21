using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField]
    GameObject gate;

    [SerializeField]
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyCounter.Instance.enemies.Count == 0)
        {
            gate.GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Player")
        {
            SceneManager.LoadScene("SecondLevel");
        }
    }
}
