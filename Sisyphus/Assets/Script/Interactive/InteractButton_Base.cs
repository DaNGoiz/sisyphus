using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButton_Base : MonoBehaviour
{
    public GameObject @base;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            @base.GetComponent<BaseInteraction>().ReturnBase();
        }
    }
}
