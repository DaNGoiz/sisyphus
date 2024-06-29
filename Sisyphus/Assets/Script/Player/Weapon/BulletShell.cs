using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShell : MonoBehaviour
{
    public float speed; //抛出速度
    public float stopTime; //停止时间
    public float fadeSpeed; //消失速度

    new private Rigidbody2D rigidbody;
    private SpriteRenderer sprite;


    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

    }

    void OnEnable()
    {
        float angle = Random.Range(-30f, 30f);
        rigidbody.velocity = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.up * speed;

        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
        rigidbody.gravityScale = 3;

        StartCoroutine(Stop());
    }
    

   IEnumerator Stop()
    {
        yield return new WaitForSeconds(stopTime);
        rigidbody.velocity = Vector2.zero;
        rigidbody.gravityScale = 0;

        while (sprite.color.a > 0)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - fadeSpeed);
            yield return new WaitForFixedUpdate();
        }
        //Destroy(gameObject);
        ObjectPool.Instance.PushObject(gameObject);
    }
}
