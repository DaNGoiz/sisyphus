using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomStoryImage : MonoBehaviour
{

    public Sprite[] stories;
    public Text word;

    // Start is called before the first frame update
    void Start()
    {
        string[] words = new string[stories.Length];
        string name = "你";

        if (PlayerPrefs.GetString("PlayerName") != null)
        {
            name = PlayerPrefs.GetString("PlayerName");
        }

        words[0] = name + " 找到了一块电池";
        words[1] = name + " 在看一张过时的宝藏地图";
        words[2] = "对机械怪物的提议，" + name + " 举双手赞成";
        words[3] = name + " 和宠物的合照";
        words[4] = name + " 今天也记得按时充电";
        words[5] = name + " 又遇到了机械怪物";
        words[6] = "《创造" + name + "》";

        int num = Random.Range(0, stories.Length);
        gameObject.GetComponent<Image>().sprite = stories[num];
        word.text = words[num];
        StartCoroutine(Closing());
    }


    IEnumerator Closing()
    {
        yield return new WaitForSeconds(2f);
        float alpha = 0f;
        Color color = gameObject.GetComponent<Image>().color;

        while (alpha <= 1)
        {
            gameObject.GetComponent<Image>().color = new Vector4(color.r - alpha, color.g - alpha, color.b - alpha, 1);
            alpha += 0.05f;
            yield return new WaitForFixedUpdate();
        }


        if (PlayerPrefs.GetInt("Dead") == 1)
        {
            PlayerPrefs.SetInt("Dead", 0);
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Time.timeScale = 1;
            // SceneManager.LoadScene(SceneNum.level_1);
            SceneManager.LoadScene(1);
        }
    }
}
