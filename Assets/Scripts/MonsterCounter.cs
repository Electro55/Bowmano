using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCounter : GameSingleton<MonsterCounter>
{
    public void AddMonster(MonsterType monsterType)
    {
        int currentCount = PlayerPrefs.GetInt(MonsterTypeKey(monsterType), 0);
        //Debug.Log(currentCount);
        currentCount++;
        PlayerPrefs.SetInt(MonsterTypeKey(monsterType), currentCount);
    }

    public int GetMonsterTypeCount(MonsterType monsterType)
    {
        //Debug.Log(MonsterTypeKey(monsterType) + ": " + PlayerPrefs.GetInt(MonsterTypeKey(monsterType), 0));
        return PlayerPrefs.GetInt(MonsterTypeKey(monsterType), 0);
    }

    private string MonsterTypeKey(MonsterType typ)
    {
        return typ.ToString();
    }

}

public enum MonsterType
{
    Slime,
    Bat,
    Rabbit
}