using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButton : MonoBehaviour
{
    public GameObject parent;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            parent.GetComponent<GearPile>().Collect();
        }
    }
}
