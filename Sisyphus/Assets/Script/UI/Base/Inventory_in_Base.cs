using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_in_Base : MonoBehaviour
{
    private void Start()
    {
        Init();
    }
    /// <summary>
    /// ��ʼ���ݵ㳡����װ����
    /// </summary>
    public void Init()
    {
        //���Ҽӽ����ģ��Ŵ���Ҳ������==
        GameObject.FindWithTag(TagName.basePanel).SetActive(true);

        int i = 0;
        foreach (Transform child in transform)
        {
            if (DataStorage.gearsInInventory[i] != null)
            {
                GameObject gear = DataStorage.gearsInInventory[i];
                gear.transform.SetParent(transform.GetChild(i));
                gear.transform.localPosition = new Vector3();
                gear.transform.rotation = Quaternion.identity;
                gear.transform.localScale = new Vector3(1, 1, 1);
                gear.SetActive(true);
            }
            i++;
        }
    }
}
