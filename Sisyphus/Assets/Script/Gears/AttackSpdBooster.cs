using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpdBooster : Gear
{
    public AttackSpdBooster(int level)
    {
        this.level = level;
        type = Type.AttackSpdBooster;
        switch (level)
        {
            case 1:
                gearName = "外壳散热片";
                attackSpdBonus = 0.1f;
                break;
            case 2:
                gearName = "机械散热片";
                attackSpdBonus = 0.2f;
                break;
            case 3:
                gearName = "水冷散热片";
                attackSpdBonus = 0.3f;
                break;
            case 4:
                gearName = "液氮散热片";
                attackSpdBonus = 0.4f;
                break;
            case 5:
                gearName = "反应堆散热片";
                attackSpdBonus = 0.5f;
                break;
            default:
                throw new UnityException("零件等级不在1-5之间。");
        }
    }
}
