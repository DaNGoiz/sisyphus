using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad_Manager : MonoBehaviour
{
    public static bool isReady;

    private void Awake()
    {
        if (isReady)
            Destroy(gameObject);
        else
        {
            DontDestroyOnLoad(gameObject);
            isReady = true;
        }
    }
}
