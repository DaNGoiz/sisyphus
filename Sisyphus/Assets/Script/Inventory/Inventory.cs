using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public bool[] isFull;
    public GameObject[] slots;

    /*
    /// <summary>
    /// 自动寻找空位存放零件
    /// </summary>
    /// <param name="gear">要存放的零件</param>
    /// <exception cref="UnityException"></exception>
    public void AddItem(GameObject gameObject)
    {
        bool canAdd = false;
        for (int i = 0; i < slots.Length; i++)
            if (slots[i] == null)
            {
                slots[i] = gameObject;
                canAdd = true;
            }
        if (!canAdd)
        {
            throw new UnityException("背包空位不足!");
        }
    }
    */
}
