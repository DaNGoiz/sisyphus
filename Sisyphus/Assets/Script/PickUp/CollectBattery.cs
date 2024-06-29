using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBattery : MonoBehaviour
{
    public float charge = 10;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Battery>().ChangeBattery(charge);
        //transform.position = player.position;
        //rotation?
        Destroy(gameObject);
    }
}
