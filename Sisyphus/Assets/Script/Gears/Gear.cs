using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Gear
{
    public enum Type
    {
        Armor,
        ExtraBattery,
        DamageBooster,
        RangeBooster,
        SpeedBooster,
        AttackSpdBooster,
    }
    public Type type;
    public int level;
    public string gearName;

    public int damageBonus = 0;
    public double armorBonus = 0;
    public float rangeBonus = 0;
    public double attackSpdBonus = 0;
    public float moveSpdBonus = 0;
    public float batteryBonus = 0;
    /// <summary>
    /// 随机返回某个等级的随机零件
    /// </summary>
    /// <param name="level">零件等级</param>
    /// <returns></returns>
    public static Gear GetRandomGear(int level)
    {
        List<Gear> pool = new List<Gear>()
        {
            new DamageBooster(level),
            new Armor(level),
            new ExtraBattery(level),
            new RangeBooster(level),
            new SpeedBooster(level),
            new AttackSpdBooster(level)
        };
        return pool[Random.Range(0, pool.Count)];
    }
    public virtual void EquipEvent(PlayerController player) { return; }
    public virtual void RemoveEvent(PlayerController player) { return; }
}
