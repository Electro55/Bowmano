using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : SceneSingleton<EnemyCounter>
{
    public event Action EnemyRemoved;

    public List<Enemy> enemies = new List<Enemy>();

    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
        EnemyRemoved?.Invoke();
    }
}
