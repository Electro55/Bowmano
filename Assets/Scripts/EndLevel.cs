using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField]
    bool shouldOpen;
    BoxCollider gate;

    public

    // Start is called before the first frame update
    void Start()
    {
        gate = GetComponentInChildren<BoxCollider>(true);
        gate.isTrigger = false;
        gate.enabled = true;
        if (shouldOpen)
            EnemyCounter.Instance.EnemyRemoved += OnEnemyRemoved;

    }

    // Update is called once per frame
    void OnEnemyRemoved()
    {
        if (EnemyCounter.Instance.enemies.Count == 0)
        {
            gate.isTrigger = true;
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.tag == "Player")
        {
            LevelLoader.Instance.LoadNextLevel();
        }
    }
}
