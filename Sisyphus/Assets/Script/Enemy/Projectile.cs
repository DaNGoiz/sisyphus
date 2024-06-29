using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float selfDestroyTime = 0.5f;

    private Transform player;
    private Vector2 target;
    private Rigidbody2D rb;

    private bool isDestroy = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        

        
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        //rb.velocity = target * speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * 0.001f);

        if(new Vector2(transform.position.x, transform.position.y) == target)
        {
            isDestroy = true;
        }

        StartCoroutine(TimeOver());

        if (isDestroy)
        {
            Destroy();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().ChangeHealth(-0.25f);
        }

        isDestroy = true;
    }

    IEnumerator TimeOver()
    {
        yield return new WaitForSeconds(selfDestroyTime);
        isDestroy = true;
    }

    private void Destroy()
    {
        //Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        //GameObject exp = ObjectPool.Instance.GetObject(explosionPrefab);
        //exp.transform.position = transform.position;

        //Destroy(gameObject);
        ObjectPool.Instance.PushObject(gameObject);

        isDestroy = false;
    }




    /*
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();


        //target = new Vector2(player.position.x, player.position.y);
        //rb.velocity = target * speed * Time.deltaTime;

        StartCoroutine(DestroyItSelf());
    }

    void FixedUpdate()
    {


        //transform.Translate(target * speed * 0.1f, Space.World);
        
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime); //跟踪：to player position，地雷：target

        //transform.Translate(player.position * speed * Time.deltaTime, Space.World); //直线

        //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);



    }

    

    IEnumerator DestroyItSelf()
    {
        yield return new WaitForSeconds(selfDestroyTime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    */
}
