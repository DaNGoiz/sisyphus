using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomTilemapSpawner : MonoBehaviour
{

    public Tilemap tilemap;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
