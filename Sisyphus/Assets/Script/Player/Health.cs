using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public double health;
    public double TotalHealth => health + GetComponent<PlayerController>().ExtraArmor;
    public int NumOfHearts
    {
        get
        {
            double ex = GetComponent<PlayerController>().ExtraArmor;
            return 3 + ((int)ex == ex ? (int)ex : (int)ex + 1);
        }
    }

    public Image[] hearts;
    public Sprite fullHeart, threeFourthHeart, halfHeart, oneFourthHeart, emptyHeart;


    public GameObject deathPanel;
    
    private void Start()
    {
        ChangeHealth(0);
    }
    
    private void Update()
    {
        if(health <= 0)
        {
            PlayerPrefs.SetInt("Dead", 1);
            deathPanel.SetActive(true);
        }
   }

    public void ChangeHealth(double value)
    {
        if (value < 0)
        {
            //使随机装备受损，若装备全部受损则玩家扣血
            //因为value是负数，所以下面用的是加法，这是没问题的
            List<Gear> gears = new();
            Gear gear;
            for (int i = 0; i < GetComponent<GearSlot>().Gears.Length; i++)
            {
                gear = GetComponent<GearSlot>().Gears[i];
                if (gear != null && gear is Armor && gear.armorBonus > 0)
                    gears.Add(gear);
            }
            if (gears.Count > 0)
            {
                while (gears.Count > 0 && value < 0)
                {
                    int randomNum = Random.Range(0, gears.Count - 1);
                    if (gears[randomNum].armorBonus <= -value)
                    {
                        value += gears[randomNum].armorBonus;
                        gears[randomNum].armorBonus = 0;
                        gears.Remove(gears[randomNum]);
                    }
                    else
                    {
                        gears[randomNum].armorBonus += value;
                        value = 0;
                    }
                }
            }
        }

        health += value;
        if (TotalHealth > NumOfHearts)
        {
            health = NumOfHearts - GetComponent<PlayerController>().ExtraArmor;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < TotalHealth)
            {
                int h1 = (int)TotalHealth;
                if (TotalHealth % h1 == 0)
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    double h2 = TotalHealth % h1;
                    if (h2 >= 0 && h2 < 0.25)
                    {
                        hearts[h1].sprite = emptyHeart;
                    }
                    else if (h2 >= 0.25 && h2 < 0.5)
                    {
                        hearts[h1].sprite = oneFourthHeart;
                    }
                    else if (h2 >= 0.5 && h2 < 0.75)
                    {
                        hearts[h1].sprite = halfHeart;
                    }
                    else
                    {
                        hearts[h1].sprite = threeFourthHeart;
                    }
                }
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < NumOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}