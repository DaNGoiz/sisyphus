using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetName : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetString("PlayerName") != null)
        {
            gameObject.GetComponent<TMP_Text>().text = PlayerPrefs.GetString("PlayerName");
        }
    }
}
