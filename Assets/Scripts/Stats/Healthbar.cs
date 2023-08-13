using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image image;

    private Unit unit;

    void Start()
    {
        unit = this.GetComponentInParent<Unit>();
    }

    void Update()
    {
        if (unit && unit.Hp > 0)
            image.fillAmount = ((float)unit.Hp / unit.MaxHp);
        else
            image.fillAmount = 0;
    }
}
