using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Unit
{
    private PlayerManager player;
    public PlayerManager PlayerUnit => PlayerUnit;
    private Animator animator;
    public Animator Animator => animator;
    private NavMeshAgent agent;
    public NavMeshAgent Agent => agent;

    [SerializeField]
    private float attackRange;
    public float AttackRange => attackRange;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<PlayerManager>();
        animator = GetComponentInChildren<Animator>();

        Died += OnDied;
    }

    private void Awake()
    {
        EnemyCounter.Instance.enemies.Add(this);
    }

    private void OnDied(Unit unit)
    {
        var stateManager = GetComponent<EnemyStateManager>();
        if (stateManager)
        {
            stateManager.ChangeState(EnemyState.Dying);
        }
        //SkillManager.Instance.AddXp(10);
    }
}
