using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearSlot : MonoBehaviour
{
    public int damageBonus;
    public double armorBonus;
    public float rangeBonus;
    public double attackSpdBonus;
    public float moveSpdBonus;
    public float batteryBonus;

    private Gear[] gears = new Gear[5];
    public Gear[] Gears 
    { 
        get { return gears; } 
        set { gears = value; RefreshPropertyPanel(); }
    }
    public void RefreshPropertyPanel()
    {
        damageBonus = 0;
        armorBonus = 0;
        rangeBonus = 0;
        attackSpdBonus = 0;
        moveSpdBonus = 0;
        batteryBonus = 0;
        foreach (Gear gear in gears)
        {
            if (gear != null)
            {
                damageBonus += gear.damageBonus;
                armorBonus += gear.armorBonus;
                rangeBonus += gear.rangeBonus;
                attackSpdBonus += gear.attackSpdBonus;
                moveSpdBonus += gear.moveSpdBonus;
                batteryBonus += gear.batteryBonus;
            }
        }
    }
}
