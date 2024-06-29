using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectClearanceProp : MonoBehaviour
{
    public Text textLabel;

    private int currentProp;
    private int totalProp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentProp = GameObject.FindGameObjectWithTag("Player").GetComponent<ClearanceProp>().currentPropNumber;
        totalProp = GameObject.FindGameObjectWithTag("Player").GetComponent<ClearanceProp>().totalPropNumber;

        currentProp += 1;
        textLabel.text = currentProp + "/" + totalProp;

        GameObject.FindGameObjectWithTag("Player").GetComponent<ClearanceProp>().currentPropNumber += 1;

        Destroy(gameObject);
    }
}
