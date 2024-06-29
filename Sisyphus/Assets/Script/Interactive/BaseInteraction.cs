using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class BaseInteraction : MonoBehaviour
{
    public Text baseName;
    private string playerName;
    private GearGenerator gearGenerator;
    private GameObject player;
    public GameObject clear;

    int totalProp;
    int currentProp;

    private void Start()
    {
        player = GameObject.FindWithTag(TagName.player);
        gearGenerator = GameObject.FindWithTag(TagName.gearManager).GetComponent<GearGenerator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentProp = GameObject.FindWithTag("Player").GetComponent<ClearanceProp>().currentPropNumber;
        totalProp = GameObject.FindWithTag("Player").GetComponent<ClearanceProp>().totalPropNumber;


        playerName = PlayerPrefs.GetString("PlayerName");

        if(playerName == null)
        {
            playerName = "Player";
        }

        if (currentProp < totalProp)
        {
            baseName.text = playerName + " 的基地\n" + "已收集："+currentProp + "/" + totalProp;
        }
        else if(currentProp >= totalProp)
        {
            baseName.text = playerName + " 的基地\n" + "已收集：" + currentProp + "/" + totalProp + "\n收集任务完成！";
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        baseName.text = "";
    }
    public void ReturnBase()
    {
        if (DataStorage.stage < 5)
        {
            int i = 0;
            //储存零件数据，在下一个场景用
            //不要销毁物体！
            foreach (Transform child in GameObject.FindWithTag(TagName.inventoryPanel).transform)
            {
                if (child.childCount != 0)
                {
                    DataStorage.gearsInInventory[i] = child.GetChild(0).gameObject;
                    Transform gearUI = child.GetChild(0);
                    gearUI.gameObject.SetActive(false);
                    //gearUI.SetParent(GameObject.FindWithTag(TagName.dontDestroyOnLoad).transform);
                    //gearUI.GetComponent<Spawn>().item.transform.SetParent(GameObject.FindWithTag(TagName.dontDestroyOnLoad).transform);
                }
                i++;
            }
            //切换场景
            GameObject.FindWithTag(TagName.dontDestroyOnLoad).GetComponent<DataStorage>().Save();
            SceneManager.LoadScene(SceneNum.baseNum);
        }
        else
        {
            //通关！
        }
    }
}
