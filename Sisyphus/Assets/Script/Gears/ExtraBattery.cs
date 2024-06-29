using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBattery : Gear
{
    private readonly string _gearName;
    public new string gearName { get => batteryBonus == 0 ? _gearName + "(�Ѻľ�)" : _gearName; }
    public readonly float maxbattery;
    public ExtraBattery(int level)
    {
        this.level = level;
        type = Type.ExtraBattery;
        switch (level)
        {
            case 1:
                _gearName = "����������";
                batteryBonus = 50;
                break;
            case 2:
                _gearName = "��ѧ����";
                batteryBonus = 100;
                break;
            case 3:
                _gearName = "����﮵��";
                batteryBonus = 150;
                break;
            case 4:
                _gearName = "ͬλ�ص��";
                batteryBonus = 250;
                break;
            case 5:
                _gearName = "��̬����";
                batteryBonus = 400;
                break;
            default:
                throw new UnityException("����ȼ�����1-5֮�䡣");
        }
        maxbattery = batteryBonus;
    }
    public override void EquipEvent(PlayerController player)
    {
        player.GetComponent<Battery>().batteries.Clear();
        foreach (Gear gear in player.GetComponent<GearSlot>().Gears)
            if (gear != null && gear is ExtraBattery && gear.batteryBonus > 0)
                player.GetComponent<Battery>().batteries.Add(gear as ExtraBattery);
        player.GetComponent<Battery>().fullBattery += maxbattery;
    }
    public override void RemoveEvent(PlayerController player)
    {
        player.GetComponent<Battery>().batteries.Clear();
        foreach (Gear gear in player.GetComponent<GearSlot>().Gears)
            if (gear != null && gear is ExtraBattery && gear.batteryBonus > 0)
                player.GetComponent<Battery>().batteries.Add(gear as ExtraBattery);
        player.GetComponent<Battery>().fullBattery -= maxbattery;
    }
}
