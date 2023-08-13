using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour
{
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        if (text != null)
        {
            StatsManager.Instance.MoneyChanged += OnMoneyChanged;
            OnMoneyChanged();
        }
    }

    private void OnMoneyChanged()
    {
        text.text = $"${StatsManager.Instance.Money}";
    }

    private void OnDestroy()
    {
        StatsManager.Instance.MoneyChanged -= OnMoneyChanged;
    }
}
