using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translucent : MonoBehaviour
{
    public float fadeSpeed = 0.05f;
    public float alpha = 0.5f;
    float setAlpha = 1f;

    Color color;

    private void Start()
    {
        color = gameObject.GetComponent<SpriteRenderer>().color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            StartCoroutine(TransparentOn());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(TransparentOff());
    }

    IEnumerator TransparentOn()
    {
        while (setAlpha >= alpha)
        {
            setAlpha -= 0.1f;
            gameObject.GetComponent<SpriteRenderer>().color = new Vector4(color.r, color.g, color.b, setAlpha);
            yield return new WaitForSeconds(fadeSpeed);
        }

    }

    IEnumerator TransparentOff()
    {
        while (setAlpha < 1f)
        {
            setAlpha += 0.1f;
            gameObject.GetComponent<SpriteRenderer>().color = new Vector4(color.r, color.g, color.b, setAlpha);
            yield return new WaitForSeconds(fadeSpeed);
        }
    }

    
}
