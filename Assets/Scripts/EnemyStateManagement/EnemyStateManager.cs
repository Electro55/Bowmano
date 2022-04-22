using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    [SerializeField]
    private EnemyState defaultState;

    PlayerManager player;
    Enemy enemy;

    private List<State> pastStates = new List<State>();

    private State currentState;
    private static Dictionary<EnemyState, Type> types = new Dictionary<EnemyState, Type> {
        { EnemyState.FollowingPlayer, typeof(StateFollowingPlayer) },
        { EnemyState.Attacking, typeof(StateAttacking) },
        { EnemyState.Dying, typeof(StateDying) }
    };

    public void ChangeState(EnemyState newState)
    {
        if (currentState)
        {
            currentState.enabled = false;
        }
        if (!pastStates.Exists(x => x.GetType() == types[newState]))
        {
            currentState = gameObject.AddComponent(types[newState]) as State;
            pastStates.Add(currentState);
        }
        else
        {
            currentState = pastStates.First(x => x.GetType() == types[newState]);
            currentState.enabled = true;
        }
        currentState.InitState(player, enemy);
        //Debug.Log(currentState);
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerManager>();
        enemy = GetComponent<Enemy>();
        ChangeState(defaultState);
    }

    // Update is called once per frame
    void Update()
    {
        var newState = currentState.TryToChangeState();
        if (newState != currentState.EnemyState)
        {

            ChangeState(newState);
        }

        currentState.Act();
    }
}

public enum EnemyState
{
    FollowingPlayer,
    Attacking,
    Dying
}
