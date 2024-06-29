using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [Header("UI Component")]
    public Text textLabel;
    public Image faceImage;

    [Header("Word Document")]
    public TextAsset textFile;
    public int index;
    public float textSpeed=0.1f;

    [Header("Avatar")]
    public Sprite face1, face2;

    bool textFinished;
    bool cancelTyping;

    List<string> textList = new List<string>();

    // Start is called before the first frame update
    void Awake()
    {
        GetTextFromFile(textFile);
    }

    private void OnEnable()
    {
        textFinished = true;
        StartCoroutine(SetTextUI());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (textFinished && !cancelTyping)
            {
                StartCoroutine(SetTextUI());
            }
            else if (!textFinished)
            {
                cancelTyping = !cancelTyping;
            }
        }
    }

    void GetTextFromFile(TextAsset textFile)
    {
        textList.Clear();
        index = 0;

        var lineData = textFile.text.Split('\n');

        foreach(var line in lineData)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel.text = "";

        switch (textList[index])
        {
            case "A":
                faceImage.sprite = face1;
                index++;
                break;
            case "B":
                faceImage.sprite = face2;
                index++;
                break;
        }

        int letter = 0;
        while (!cancelTyping && letter < textList[index].Length - 1)
        {
            textLabel.text += textList[index][letter];
            letter++;
            yield return new WaitForSeconds(textSpeed);
        }
        textLabel.text = textList[index];
        cancelTyping = false;

        textFinished = true;
        index++;
    }
}
