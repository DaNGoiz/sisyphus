using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathDialog : MonoBehaviour
{

    public Text deathText;
    private string playerName;
    public GameObject board;

    // Start is called before the first frame update
    void Start()
    {
        playerName = PlayerPrefs.GetString("PlayerName");
        //Time.timeScale = 0;
        StartCoroutine(DeathNote());
    }


    IEnumerator DeathNote()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().health <= 0)
        {
            deathText.text = playerName + "被解体！\n" + "将在 (3) 秒后重启";
            yield return new WaitForSeconds(1);
            deathText.text = playerName + "被解体！\n" + "将在 (2) 秒后重启";
            yield return new WaitForSeconds(1);
            deathText.text = playerName + "被解体！\n" + "将在 (1) 秒后重启";
            yield return new WaitForSeconds(1);
            deathText.text = playerName + "被解体！\n" + "将在 (0) 秒后重启";
            yield return new WaitForSeconds(1);
        }

        if(GameObject.FindGameObjectWithTag("Player").GetComponent<Battery>().TotalBattery <= 0)
        {
            deathText.text = playerName + "能量耗尽！\n" + "将在 (3) 秒后重启";
            yield return new WaitForSeconds(1);
            deathText.text = playerName + "能量耗尽！\n" + "将在 (2) 秒后重启";
            yield return new WaitForSeconds(1);
            deathText.text = playerName + "能量耗尽！\n" + "将在 (1) 秒后重启";
            yield return new WaitForSeconds(1);
            deathText.text = playerName + "能量耗尽！\n" + "将在 (0) 秒后重启";
            yield return new WaitForSeconds(1);
        }
        
        board.SetActive(true);
    }
}
