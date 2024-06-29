using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearanceProp : MonoBehaviour
{
    public int totalPropNumber;
    public int currentPropNumber;

    public Text text;

    private void Start()
    {
        currentPropNumber = 0;
        text.text = currentPropNumber + "/" + totalPropNumber;
    }
}
