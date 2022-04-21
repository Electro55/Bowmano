using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : SceneSingleton<EnemyCounter>
{
    public List<Enemy> enemies = new List<Enemy>();
}
