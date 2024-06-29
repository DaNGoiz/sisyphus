using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage_in_Base : MonoBehaviour
{
    private void Start()
    {
        Init();
    }
    public void Init()
    {
        int i = 0;
        foreach (Transform child in transform)
        {
            if (DataStorage.gearsInBaseStorage[i] != null)
            {
                GameObject gear = DataStorage.gearsInBaseStorage[i];
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
