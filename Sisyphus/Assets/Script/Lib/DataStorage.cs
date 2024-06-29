using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DataStorage : MonoBehaviour
{
    public static int stage = 1;
    public static GameObject[] gearsInInventory;
    public static GameObject[] gearsInBaseStorage;
    private void Awake()
    {
        if (gearsInInventory == null)
            gearsInInventory = new GameObject[5];
        if (gearsInBaseStorage == null)
            gearsInBaseStorage = new GameObject[10];
    }
    public void Save()
    {
        foreach (GameObject go in gearsInInventory)
        {
            if (go != null)
            {
                go.GetComponent<Spawn>().item.transform.SetParent(transform, false);
                go.transform.SetParent(transform, false);
            }
        }
        foreach (GameObject go in gearsInBaseStorage)
        {
            if (go != null)
            {
                go.GetComponent<Spawn>().item.transform.SetParent(transform, false);
                go.transform.SetParent(transform, false);
            }
        }
    }
}
