using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInitialize : MonoBehaviour
{
    private GearGenerator gearGenerator;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindWithTag(TagName.player);
        gearGenerator = GameObject.FindWithTag(TagName.gearManager).GetComponent<GearGenerator>();

        EquipmentInit();
    }

    private void EquipmentInit()
    {
        player.GetComponent<GearSlot>().Gears.Initialize();
        player.GetComponent<GearSlot>().RefreshPropertyPanel();
        GameObject panel = GameObject.FindWithTag(TagName.inventoryPanel);
        int i = 0;
        //简单粗暴而又粗糙的方法！我不管！能跑就行！没时间了！！！！！
        foreach (GameObject gear in DataStorage.gearsInInventory)
        {
            if (gear != null)
            {
                gear.transform.SetParent(panel.transform.GetChild(i));
                player.GetComponent<Inventory>().isFull[i] = true;
                gear.transform.localPosition = new Vector3();
                gear.transform.rotation = Quaternion.identity;
                gear.transform.localScale = new Vector3(1, 1, 1);
                gear.SetActive(true);
                player.GetComponent<PlayerController>().Equip(gear.GetComponent<Spawn>().item.GetComponent<PickUpItem>().item);
            }
            i++;
        }
    }
}
