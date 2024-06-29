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
                gearName = "С�ھ�װҩ��";
                rangeBonus = 0.1f;
                break;
            case 2:
                gearName = "����װҩ��";
                rangeBonus = 0.3f;
                break;
            case 3:
                gearName = "��ǹװҩ��";
                rangeBonus = 0.5f;
                break;
            case 4:
                gearName = "����װҩ��";
                rangeBonus = 0.7f;
                break;
            case 5:
                gearName = "�ѻ�װҩ��";
                rangeBonus = 1f;
                break;
            default:
                throw new UnityException("����ȼ�����1-5֮�䡣");
        };
    }
}
