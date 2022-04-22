using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : GameSingleton<StatsManager>
{
    public event Action MoneyChanged;
    [SerializeField]
    private int money;
    private float attackSpeedMult = 1;
    private float damageMult = 1;
    private float hpMult = 1;

    public ProductData AttackSpeed;
    public ProductData Damage;
    public ProductData HP;

    public int Money { get => money; set  { money = value; MoneyChanged?.Invoke(); PlayerPrefs.SetInt("Money", value); } }
    public float AttackSpeedMult { get => attackSpeedMult; set { attackSpeedMult = value; } }
    public float DamageMult { get => damageMult; set { damageMult = value; } }
    public float HpMult { get => hpMult; set { hpMult = value; } }

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        Money = PlayerPrefs.GetInt("Money", 100);
        AttackSpeed.InitMult();
        Damage.InitMult();
        HP.InitMult();
    }

    public ProductData GetProductDataByType(ProductType prodType)
    {
        switch (prodType)
        {
            case ProductType.HP:
                return HP;
            case ProductType.Damage:
                return Damage;
            case ProductType.AttackSpeed:
                return AttackSpeed;
        }
        return HP;
    }

}
