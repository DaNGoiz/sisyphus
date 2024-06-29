using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float time => 0.06f;
    public int Damage => player.Damage;

    public GameObject explosionPrefab;
    new private Rigidbody2D rigidbody;
    private PlayerController player;

    private bool isDestroy;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag(TagName.player).GetComponent<PlayerController>();
    }

    public void SetSpeed(Vector2 direction)
    {
        rigidbody.velocity = direction * speed;
    }

    private void Update()
    {
        StartCoroutine(TimeOver());

        if (isDestroy)
        {
            Destroy();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().enemyHealth -= Damage;
            //GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().health -= 0.25;
        }
        isDestroy = true;
    }

    IEnumerator TimeOver()
    {
        yield return new WaitForSeconds(time);
        isDestroy = true;
    }

    private void Destroy()
    {
        //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        GameObject exp = ObjectPool.Instance.GetObject(explosionPrefab);
        exp.transform.position = transform.position;

        //Destroy(gameObject);
        ObjectPool.Instance.PushObject(gameObject);

        isDestroy = false;
    }
}
