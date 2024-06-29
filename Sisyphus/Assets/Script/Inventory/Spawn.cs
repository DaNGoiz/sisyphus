using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    public float spawnDistance = 3f;
    private Transform player;

    void Start()
    {
    }

    public void SpawnDroppedItem()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag(TagName.player).transform;
        Vector2 playerPos = new Vector2(player.position.x, player.position.y + spawnDistance);
        item.SetActive(true);
        item.transform.position = playerPos;
    }
}
