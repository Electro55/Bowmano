using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    private ProductData productData;
    public ProductData ProductData => productData;

    [SerializeField]
    private ProductType productType;

    [SerializeField]
    private Image icon;
    [SerializeField]
    private Text productName;
    [SerializeField]
    private Text mult;
    [SerializeField]
    private Text price;
    [SerializeField]
    private Button button;

    public void Start()
    {
        productData = StatsManager.Instance.GetProductDataByType(productType);

        SetData();
        button.onClick.AddListener(OnBuyClicked);

        productData.Bought += OnBought;
    }

    private void SetData()
    {
        icon.sprite = productData.icon;
        productName.text = productData.name;
        mult.text = $"(x{productData.FinalMultStr})";
        price.text = $"(x{productData.price})";
    }

    private void OnBought(ProductData obj)
    {
        SetData();
    }

    private void OnBuyClicked()
    {
        productData.RequestBuy();
    }
}

[Serializable]
public class ProductData
{
    public event Action<ProductData> Bought;

    public float levelMult;
    public string name;
    public int price;
    public int levelBought;
    public Sprite icon;

    public ProductType productType;

    public string FinalMultStr
    {
        get
        {
            return FinalMult.ToString("F1");
        }
    }

    public float FinalMult
    {
        get
        {
            return (1 + levelBought * levelMult);
        }
    }


    public void InitMult()
    {
        levelBought = PlayerPrefs.GetInt(name, 0);
        for (int i = 0; i < levelBought; i++)
            price = (int)((levelMult+1)*price);
    }

    public void RequestBuy()
    {
        if(price <= StatsManager.Instance.Money)
        {
            StatsManager.Instance.Money -= price;
            levelBought++;
            price = (int)((levelMult + 1) * price);
            PlayerPrefs.SetInt(name, levelBought);
            Bought?.Invoke(this);
        }
    }

}

public enum ProductType
{
    HP,
    Damage,
    AttackSpeed
}