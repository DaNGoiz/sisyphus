using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    */

    public float shootDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public float enemyHealth = 5;

    public GameObject projectile;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Camera.main.transform.rotation;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) <= stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        */

        if (Vector2.Distance(transform.position, player.position) < shootDistance)
        {
            if (timeBtwShots <= 0)
            {
                Instantiate(projectile, transform.position, Camera.main.transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
        
    }
}
