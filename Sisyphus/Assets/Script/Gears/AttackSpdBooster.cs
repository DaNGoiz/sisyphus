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
                gearName = "���ɢ��Ƭ";
                attackSpdBonus = 0.1f;
                break;
            case 2:
                gearName = "��еɢ��Ƭ";
                attackSpdBonus = 0.2f;
                break;
            case 3:
                gearName = "ˮ��ɢ��Ƭ";
                attackSpdBonus = 0.3f;
                break;
            case 4:
                gearName = "Һ��ɢ��Ƭ";
                attackSpdBonus = 0.4f;
                break;
            case 5:
                gearName = "��Ӧ��ɢ��Ƭ";
                attackSpdBonus = 0.5f;
                break;
            default:
                throw new UnityException("����ȼ�����1-5֮�䡣");
        }
    }
}
