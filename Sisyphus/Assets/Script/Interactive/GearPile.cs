using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearPile : MonoBehaviour
{
    //按稀有度-阶段-等级顺序排列
    private int[,,] gearGenChance;
    private int[] batteryGenChance;
    public GameObject interactButton;

    public Sprite[] sprites;
    private GameObject player;
    public enum Rarity
    {
        White,
        Blue,
        Purple,
        Golden
    }
    public Rarity rarity;
    private int[] batteryConsumption;
    public Gear content;
    private int[] rarityChance;
    public GameObject battery;
    private void Awake()
    {
        gearGenChance = new int[4, 5, 5] 
        { 
            { { 100, 0, 0, 0, 0 }, { 60, 40, 0, 0, 0 }, { 20, 30, 50, 0, 0 }, { 0, 20, 50, 30, 0 }, { 0, 20, 40, 35, 5 } },
            { { 80, 20, 0, 0, 0 }, { 40, 60, 0, 0, 0 }, { 10, 35, 55, 0, 0 }, { 0, 10, 20, 70, 0 }, { 0, 0, 20, 50, 30 } }, 
            { { 50, 50, 0, 0, 0 }, { 10, 70, 20, 0, 0 }, { 0, 30, 60, 10, 0 }, { 0, 0, 20, 75, 5 }, { 0, 0, 10, 40, 50 } },
            { { 10, 85, 5, 0, 0 }, { 0, 30, 60, 10, 0 }, { 0, 10, 59, 30, 1 }, { 0, 0, 20, 60, 20 }, { 0, 0, 0, 10, 90 } }
        };
        batteryGenChance = new int[4] { 20, 50, 80, 90 };
        batteryConsumption = new int[4] { 5, 10, 15, 20 };
        rarityChance = new int[4] { 50, 25, 15, 5 };
    }
    private void Start()
    {
        player = GameObject.FindWithTag(TagName.player);
        rarity = (Rarity)GetRarityRandom();
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(1, sprites.Length)];
    }
    public void Collect()
    {
        //播放收集动画
        //收集可中断
        //消耗电量
        if (player.GetComponent<Battery>().TotalBattery < batteryConsumption[(int)rarity])
        {
            Debug.Log("无法采集");
            return;
        }
        else
        {
            player.GetComponent<Battery>().ChangeBattery(-batteryConsumption[(int)rarity]);
        }
        //收集随机装备
        int flag = 0;
        while (flag == 0) flag = Random.Range(-1, 2);
        float x = Random.Range(transform.position.x + (flag * 0.5f), transform.position.x + (flag * 0.3f));
        flag = 0;
        while (flag == 0) flag = Random.Range(-1, 2);
        float y = Random.Range(transform.position.y + (flag * 0.5f), transform.position.y + (flag * 0.3f));
        GameObject.FindGameObjectWithTag(TagName.gearManager).GetComponent<GearGenerator>().Generate(
            Gear.GetRandomGear(GetLevelRandom()), new Vector2(x, y), Camera.main.transform.rotation);
        //随机额外生成电池
        if (Random.Range(1, 101) < batteryGenChance[(int)rarity])
        {
            flag = 0;
            while (flag == 0) flag = Random.Range(-1, 2);
            x = Random.Range(transform.position.x + (flag * 0.5f), transform.position.x + (flag * 0.3f));
            flag = 0;
            while (flag == 0) flag = Random.Range(-1, 2);
            y = Random.Range(transform.position.y + (flag * 0.5f), transform.position.y + (flag * 0.3f));
            Instantiate(battery, new Vector2(x, y), Camera.main.transform.rotation);
        }
        Destroy(gameObject);
    }

    private int GetLevelRandom()
    {
        int randInt = Random.Range(1, 101);
        int edge = gearGenChance[(int)rarity, DataStorage.stage - 1, 0];
        for (int i = 0; i < 4; i++)
        {
            if (randInt <= edge)
                return i + 1;
            else
                edge += gearGenChance[(int)rarity, DataStorage.stage - 1, i + 1];
        }
        return 5;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        interactButton.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        interactButton.SetActive(false);
    }
    private int GetRarityRandom()
    {
        int randInt = Random.Range(1, 101);
        int edge = rarityChance[0];
        for (int i = 0; i < 3; i++)
        {
            if (randInt <= edge)
                return i;
            else
                edge += gearGenChance[(int)rarity, DataStorage.stage - 1, i + 1];
        }
        return 3;
    }
}
