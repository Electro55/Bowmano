using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsScreen : MenuScreen
{

    public Text slimeText;
    public Text batText;
    public Text bunnyText;

    public override void Enable()
    {
        base.Enable();
        slimeText.text = $"{MonsterCounter.Instance.GetMonsterTypeCount(MonsterType.Slime)}x";
        batText.text = $"{MonsterCounter.Instance.GetMonsterTypeCount(MonsterType.Bat)}x";
        bunnyText.text = $"{MonsterCounter.Instance.GetMonsterTypeCount(MonsterType.Rabbit)}x";
    }
}
