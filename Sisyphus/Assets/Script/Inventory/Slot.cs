using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    Inventory inventory;
    PlayerController player;
    public int i; //每个槽都要有，编号0-n

    
    private void Start()
    {
        player = GameObject.FindWithTag(TagName.player).GetComponent<PlayerController>();
        inventory = player.GetComponent<Inventory>();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
    }

    public void DropItem()
    {
        foreach(Transform child in transform)
        {
            player.RemoveEquipment(child.GetComponent<Spawn>().item.GetComponent<PickUpItem>().item);
            child.GetComponent<Spawn>().SpawnDroppedItem();
            Destroy(child.gameObject);
        }
    }
}
