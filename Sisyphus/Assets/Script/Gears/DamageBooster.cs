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
                gearName = "�ֹ�����ǹ��";
                damageBonus = 1;
                break;
            case 2:
                gearName = "��ѹ����ǹ��";
                damageBonus = 2;
                break;
            case 3:
                gearName = "���ǹ��";
                damageBonus = 5;
                break;
            case 4:
                gearName = "���Ӽ���ǹ��";
                damageBonus = 6;
                break;
            case 5:
                gearName = "��˹��Ȧǹ��";
                damageBonus = 10;
                break;
            default:
                throw new UnityException("����ȼ�����1-5֮�䡣");
        };
    }
}
