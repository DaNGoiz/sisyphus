using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public bool[] isFull;
    public GameObject[] slots;

    /*
    /// <summary>
    /// �Զ�Ѱ�ҿ�λ������
    /// </summary>
    /// <param name="gear">Ҫ��ŵ����</param>
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
            throw new UnityException("������λ����!");
        }
    }
    */
}
