using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeBooster : Gear
{
    public RangeBooster(int level)
    {
        this.level = level;
        type = Type.RangeBooster;
        switch (level)
        {
            case 1:
                gearName = "小口径装药弹";
                rangeBonus = 0.1f;
                break;
            case 2:
                gearName = "轻型装药弹";
                rangeBonus = 0.3f;
                break;
            case 3:
                gearName = "步枪装药弹";
                rangeBonus = 0.5f;
                break;
            case 4:
                gearName = "重型装药弹";
                rangeBonus = 0.7f;
                break;
            case 5:
                gearName = "狙击装药弹";
                rangeBonus = 1f;
                break;
            default:
                throw new UnityException("零件等级不在1-5之间。");
        };
    }
}
