using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : Gear
{
    public SpeedBooster(int level)
    {
        this.level = level;
        type = Type.SpeedBooster;
        //注意还未设定速度加成具体数值！
        switch (level)
        {
            case 1:
                gearName = "转子发动机";
                moveSpdBonus = 0.05f;
                break;
            case 2:
                gearName = "强磁力发动机";
                moveSpdBonus = 0.09f;
                break;
            case 3:
                gearName = "引擎发动机";
                moveSpdBonus = 0.13f;
                break;
            case 4:
                gearName = "军工发动机";
                moveSpdBonus = 0.18f;
                break;
            case 5:
                gearName = "外骨骼发动机";
                moveSpdBonus = 0.25f;
                break;
            default:
                throw new UnityException("零件等级不在1-5之间。");
        }
    }
}
