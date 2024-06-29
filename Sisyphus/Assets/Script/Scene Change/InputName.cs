using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputName : MonoBehaviour
{
    public GameObject enter;
    public GameObject success;
    public GameObject storyImage;
    public TMP_InputField inputName;

    string playerName;
    private bool canStartGame;

    private void Update()
    {
        if (canStartGame)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                enter.SetActive(false);
                if(inputName.text == "")
                {
                    playerName = "Player";
                }
                else
                {
                    playerName = inputName.text;
                }
                StartCoroutine(SetNameSuccess());
            }
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
        canStartGame = true;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        canStartGame = false;
    }

    IEnumerator SetNameSuccess()
    {
        PlayerPrefs.SetString("PlayerName", playerName);
        success.SetActive(true);
        //名字+倒数
        success.GetComponent<Text>().text = "(^-^)/ 你的名字是 " + playerName + " (3)";
        yield return new WaitForSeconds(1f);
        success.GetComponent<Text>().text = "(^-^)/ 你的名字是 " + playerName + " (2)";
        yield return new WaitForSeconds(1f);
        success.GetComponent<Text>().text = "(^-^)/ 你的名字是 " + playerName + " (1)";
        yield return new WaitForSeconds(1f);
        success.GetComponent<Text>().text = "(^-^)/ 你的名字是 " + playerName + " (0)";
        yield return new WaitForSeconds(1f);
        storyImage.SetActive(true);
    }

    
}
