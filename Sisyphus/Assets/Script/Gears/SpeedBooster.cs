using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : Gear
{
    public SpeedBooster(int level)
    {
        this.level = level;
        type = Type.SpeedBooster;
        //ע�⻹δ�趨�ٶȼӳɾ�����ֵ��
        switch (level)
        {
            case 1:
                gearName = "ת�ӷ�����";
                moveSpdBonus = 0.05f;
                break;
            case 2:
                gearName = "ǿ����������";
                moveSpdBonus = 0.09f;
                break;
            case 3:
                gearName = "���淢����";
                moveSpdBonus = 0.13f;
                break;
            case 4:
                gearName = "����������";
                moveSpdBonus = 0.18f;
                break;
            case 5:
                gearName = "�����������";
                moveSpdBonus = 0.25f;
                break;
            default:
                throw new UnityException("����ȼ�����1-5֮�䡣");
        }
    }
}
