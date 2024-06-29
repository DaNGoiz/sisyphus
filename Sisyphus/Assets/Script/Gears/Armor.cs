using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Gear
{
    private readonly string _gearName;
    public new string gearName { get => armorBonus == 0 ? _gearName + "(����)" : _gearName; }
    public Armor(int level)
    {
        this.level = level;
        type = Type.Armor;
        switch (level)
        {
            case 1:
                _gearName = "���������";
                armorBonus = 1;
                break;
            case 2:
                _gearName = "��ͭ���";
                armorBonus = 2;
                break;
            case 3:
                _gearName = "�������";
                armorBonus = 4;
                break;
            case 4:
                _gearName = "��Ƹ����";
                armorBonus = 6;
                break;
            case 5:
                _gearName = "����������";
                armorBonus = 10;
                break;
            default:
                throw new UnityException("����ȼ�����1-5֮�䡣");
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
