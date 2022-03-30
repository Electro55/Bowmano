using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image image;

    public CharacterStats player;

    void Start()
    {
        player = this.GetComponentInParent<CharacterStats>();
    }

    void Update()
    {
        if (player.currentHealthPoints > 0)
            image.fillAmount = ((float)player.currentHealthPoints / player.maxHealthPoints);
        else
            image.fillAmount = 0;
    }
}
