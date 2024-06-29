using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBattery : Gear
{
    private readonly string _gearName;
    public new string gearName { get => batteryBonus == 0 ? _gearName + "(已耗尽)" : _gearName; }
    public readonly float maxbattery;
    public ExtraBattery(int level)
    {
        this.level = level;
        type = Type.ExtraBattery;
        switch (level)
        {
            case 1:
                _gearName = "土豆伏打电池";
                batteryBonus = 50;
                break;
            case 2:
                _gearName = "化学蓄电池";
                batteryBonus = 100;
                break;
            case 3:
                _gearName = "单兵锂电池";
                batteryBonus = 150;
                break;
            case 4:
                _gearName = "同位素电池";
                batteryBonus = 250;
                break;
            case 5:
                _gearName = "固态氢电池";
                batteryBonus = 400;
                break;
            default:
                throw new UnityException("零件等级不在1-5之间。");
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
