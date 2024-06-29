using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    public Gear item;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (inventory == null)
                inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    GameObject ui = Instantiate(itemButton, inventory.slots[i].transform);
                    ui.GetComponent<Image>().sprite = GetComponent<SpriteRenderer>().sprite;
                    ui.GetComponent<Spawn>().item = gameObject;
                    other.GetComponent<PlayerController>().Equip(item);
                    gameObject.SetActive(false);
                    break;
                }
            }
        }
    }
}
