using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAtNewLevelStart : MonoBehaviour
{
    public GameObject background;
    public GameObject textBoardLevel;
    public GameObject textBoardProb;

    public Text textLevel;
    public Text textProb;

    private int totalProb;
    private int level;

    void Start()
    {
        totalProb = GameObject.FindGameObjectWithTag("Player").GetComponent<ClearanceProp>().totalPropNumber;
        //level = GameObject.FindGameObjectWithTag("Player").GetComponent<Level>().level;

        textProb.text = "0/" + totalProb + " 并带回基地！";
        //textLevel.text = "第" + level + "关";

        StartCoroutine(WaitAndLeave());
    }

    IEnumerator WaitAndLeave()
    {
        yield return new WaitForSeconds(3);

        float alpha = 1;

        while (alpha >= 0)
        {
            foreach (Transform child in transform)
            {
                if (child.GetComponent<Image>() == true)
                {
                    Color color = child.GetComponent<Image>().color;
                    child.GetComponent<Image>().color = new Vector4(color.r, color.g, color.b, color.a - 0.1f);
                }
                else if (child.GetComponent<Text>() == true)
                {
                    Color color = child.GetComponent<Text>().color;
                    child.GetComponent<Text>().color = new Vector4(color.r, color.g, color.b, alpha);
                }
            }
            alpha -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        gameObject.SetActive(false);
    }
}
