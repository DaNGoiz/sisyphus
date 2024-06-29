using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearGenerator : MonoBehaviour
{
    public GameObject prefab;
    public GameObject UIprefab;

    #region װ����ͼ
    public Sprite[] armorSprite;
    public Sprite[] extraBatterySprite;
    public Sprite[] damageBoosterSprite;
    public Sprite[] rangeBoosterSprite;
    public Sprite[] speedBoosterSprite;
    public Sprite[] attackSpdBoosterSprite;
    #endregion
    /// <summary>
    /// ����װ��Ԥ�Ƽ����������ɵ�ʵ��
    /// </summary>
    /// <param name="type">װ������</param>
    /// <param name="level">�ȼ�</param>
    /// <returns>���ɵ�װ��ʵ��</returns>
    public GameObject Generate(Gear.Type type, int level)
    {
        GameObject go = Instantiate(prefab);
        switch (type)
        {
            case Gear.Type.Armor:
                go.GetComponent<PickUpItem>().item = new Armor(level);
                go.GetComponent<SpriteRenderer>().sprite = armorSprite[level - 1];
                break;
            case Gear.Type.ExtraBattery:
                go.GetComponent<PickUpItem>().item = new ExtraBattery(level);
                go.GetComponent<SpriteRenderer>().sprite = extraBatterySprite[level - 1];
                break;
            case Gear.Type.DamageBooster:
                go.GetComponent<PickUpItem>().item = new DamageBooster(level);
                go.GetComponent<SpriteRenderer>().sprite = damageBoosterSprite[level - 1];
                break;
            case Gear.Type.RangeBooster:
                go.GetComponent<PickUpItem>().item = new RangeBooster(level);
                go.GetComponent<SpriteRenderer>().sprite = rangeBoosterSprite[level - 1];
                break;
            case Gear.Type.SpeedBooster:
                go.GetComponent<PickUpItem>().item = new SpeedBooster(level);
                go.GetComponent<SpriteRenderer>().sprite = speedBoosterSprite[level - 1];
                break;
            case Gear.Type.AttackSpdBooster:
                go.GetComponent<PickUpItem>().item = new AttackSpdBooster(level);
                go.GetComponent<SpriteRenderer>().sprite = attackSpdBoosterSprite[level - 1];
                break;
            default:
                break;
        }
        return go;
    }
    /// <summary>
    /// ����װ��Ԥ�Ƽ����������ɵ�ʵ��
    /// </summary>
    /// <param name="type">װ������</param>
    /// <param name="level">�ȼ�</param>
    /// <returns>���ɵ�װ��ʵ��</returns>
    public GameObject Generate(Gear.Type type, int level, Vector3 position, Quaternion rotation)
    {
        GameObject go = Instantiate(prefab, position, rotation);
        switch (type)
        {
            case Gear.Type.Armor:
                go.GetComponent<PickUpItem>().item = new Armor(level);
                go.GetComponent<SpriteRenderer>().sprite = armorSprite[level - 1];
                break;
            case Gear.Type.ExtraBattery:
                go.GetComponent<PickUpItem>().item = new ExtraBattery(level);
                go.GetComponent<SpriteRenderer>().sprite = extraBatterySprite[level - 1];
                break;
            case Gear.Type.DamageBooster:
                go.GetComponent<PickUpItem>().item = new DamageBooster(level);
                go.GetComponent<SpriteRenderer>().sprite = damageBoosterSprite[level - 1];
                break;
            case Gear.Type.RangeBooster:
                go.GetComponent<PickUpItem>().item = new RangeBooster(level);
                go.GetComponent<SpriteRenderer>().sprite = rangeBoosterSprite[level - 1];
                break;
            case Gear.Type.SpeedBooster:
                go.GetComponent<PickUpItem>().item = new SpeedBooster(level);
                go.GetComponent<SpriteRenderer>().sprite = speedBoosterSprite[level - 1];
                break;
            case Gear.Type.AttackSpdBooster:
                go.GetComponent<PickUpItem>().item = new AttackSpdBooster(level);
                go.GetComponent<SpriteRenderer>().sprite = attackSpdBoosterSprite[level - 1];
                break;
            default:
                break;
        }
        return go;
    }
    /// <summary>
    /// ����װ��Ԥ�Ƽ����������ɵ�ʵ��
    /// </summary>
    /// <param name="gear">װ��</param>
    /// <returns>���ɵ�װ��ʵ��</returns>
    public GameObject Generate(Gear gear)
    {
        GameObject go = Instantiate(prefab);
        go.GetComponent<PickUpItem>().item = gear;
        go.GetComponent<SpriteRenderer>().sprite = gear.type switch
        {
            Gear.Type.Armor => armorSprite[gear.level - 1],
            Gear.Type.ExtraBattery => extraBatterySprite[gear.level - 1],
            Gear.Type.DamageBooster => damageBoosterSprite[gear.level - 1],
            Gear.Type.RangeBooster => rangeBoosterSprite[gear.level - 1],
            Gear.Type.SpeedBooster => speedBoosterSprite[gear.level - 1],
            Gear.Type.AttackSpdBooster => attackSpdBoosterSprite[gear.level - 1],
            _ => null
        };
        return go;
    }
    /// <summary>
     /// ����װ��Ԥ�Ƽ����������ɵ�ʵ��
     /// </summary>
     /// <param name="gear">װ��</param>
     /// <returns>���ɵ�װ��ʵ��</returns>
    public GameObject Generate(Gear gear, Vector3 position, Quaternion rotation)
    {
        GameObject go = Instantiate(prefab, position, rotation);
        go.GetComponent<PickUpItem>().item = gear;
        go.GetComponent<SpriteRenderer>().sprite = gear.type switch
        {
            Gear.Type.Armor => armorSprite[gear.level - 1],
            Gear.Type.ExtraBattery => extraBatterySprite[gear.level - 1],
            Gear.Type.DamageBooster => damageBoosterSprite[gear.level - 1],
            Gear.Type.RangeBooster => rangeBoosterSprite[gear.level - 1],
            Gear.Type.SpeedBooster => speedBoosterSprite[gear.level - 1],
            Gear.Type.AttackSpdBooster => attackSpdBoosterSprite[gear.level - 1],
            _ => null
        };
        return go;
    }
    //��������������UI���������ģ���������Spawn�ű������һ�����Ծͻ��е��ң�Ҫ���õ����������Ժ���ò�Ҫ�ֿ���ô������д
    //�ݻ����õ��ϰ�
    /// <summary>
    /// ����װ��UIԤ�Ƽ����������ɵ�ʵ��
    /// </summary>
    /// <param name="gear">װ��</param>
    /// <returns>���ɵ�װ��ʵ��</returns>
    public GameObject GenerateUI(Gear gear)
    {
        GameObject go = Instantiate(UIprefab);
        go.GetComponent<Spawn>().item = Generate(gear);
        go.GetComponent<Image>().sprite = go.GetComponent<Spawn>().item.GetComponent<SpriteRenderer>().sprite;
        return go;
    }
    /// <summary>
    /// ����װ��UIԤ�Ƽ����������ɵ�ʵ��
    /// </summary>
    /// <param name="gear">װ��</param>
    /// <returns>���ɵ�װ��ʵ��</returns>
    public GameObject GenerateUI(Gear gear, Transform parent)
    {
        GameObject go = Instantiate(UIprefab, parent);
        go.GetComponent<Spawn>().item = Generate(gear);
        go.GetComponent<Image>().sprite = go.GetComponent<Spawn>().item.GetComponent<SpriteRenderer>().sprite;
        return go;
    }
    public void Throw(Vector2 from, Vector2 to)//������Ͷ���������ʱ����
    {
    }
    /*
    /// <summary>
    /// ����װ��UIԤ�Ƽ����������ɵ�ʵ������Ŀǰ��ʱû��ʵ��
    /// </summary>
    /// <param name="type">װ������</param>
    /// <param name="level">�ȼ�</param>
    /// <returns>���ɵ�װ��UIʵ��</returns>
    public GameObject GenerateUI(Gear.Type type, int level)
    {
        GameObject go = Instantiate(UIprefab);
    }*/
}
