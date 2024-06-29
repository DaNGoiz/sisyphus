using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomTitleImage : MonoBehaviour
{
    public Sprite[] images;

    public void RandomTitle()
    {
        int image = Random.Range(0, images.Length);
        gameObject.GetComponent<Image>().sprite = images[image];
    }
}
