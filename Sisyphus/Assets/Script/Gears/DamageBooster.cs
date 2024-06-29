using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBooster : Gear
{
    public DamageBooster(int level)
    {
        this.level = level;
        type = Type.DamageBooster;
        switch (level)
        {
            case 1:
                gearName = "手工膛线枪管";
                damageBonus = 1;
                break;
            case 2:
                gearName = "冲压膛线枪管";
                damageBonus = 2;
                break;
            case 3:
                gearName = "光刻枪管";
                damageBonus = 5;
                break;
            case 4:
                gearName = "电子加速枪管";
                damageBonus = 6;
                break;
            case 5:
                gearName = "高斯线圈枪管";
                damageBonus = 10;
                break;
            default:
                throw new UnityException("零件等级不在1-5之间。");
        };
    }
}
