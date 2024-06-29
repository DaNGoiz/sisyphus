using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Gear
{
    private readonly string _gearName;
    public new string gearName { get => armorBonus == 0 ? _gearName + "(已损坏)" : _gearName; }
    public Armor(int level)
    {
        this.level = level;
        type = Type.Armor;
        switch (level)
        {
            case 1:
                _gearName = "混凝土外壳";
                armorBonus = 1;
                break;
            case 2:
                _gearName = "黄铜外壳";
                armorBonus = 2;
                break;
            case 3:
                _gearName = "铸铁外壳";
                armorBonus = 4;
                break;
            case 4:
                _gearName = "电镀钢外壳";
                armorBonus = 6;
                break;
            case 5:
                _gearName = "航天材料外壳";
                armorBonus = 10;
                break;
            default:
                throw new UnityException("零件等级不在1-5之间。");
        }
    }
    public override void EquipEvent(PlayerController player)
    {
        player.GetComponent<Health>().ChangeHealth(0);
    }
    public override void RemoveEvent(PlayerController player)
    {
        player.GetComponent<Health>().ChangeHealth(0);
    }
}
