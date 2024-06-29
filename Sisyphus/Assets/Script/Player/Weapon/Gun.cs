using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private PlayerController player;
    public double defaultInterval;
    public double Interval => defaultInterval * (1 /player.AttackSpd);
    public GameObject bulletPrefab;
    public GameObject shellPrefab;

    private Transform headPos; //枪口位置
    private Transform rootPos; //握把位置
    public Transform bulletPos; //debug

    private Vector2 mousePos;
    private Vector2 direction;

    private double timer;

    private float flipY;

    private Animator animator;

    public GameObject mousePoint;

    float x, y;

    
    void Start()
    {
        player = GameObject.FindWithTag(TagName.player).GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        headPos = transform.Find("Head");
        rootPos = transform.Find("Root");
        flipY = transform.localScale.y;
    }

    void FixedUpdate()
    {
        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        x = Input.mousePosition.x - Screen.width / 2f;
        y = Input.mousePosition.y - Screen.height / 2f;

        mousePos = new Vector2(x, y);

        transform.rotation = Camera.main.transform.rotation;

        
        if (mousePos.x < transform.position.x)
        {
            transform.localScale = new Vector3(transform.localScale.x, -flipY, transform.localScale.z);
            //transform.position += new Vector3(-0.02f, 0, 0);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, flipY, transform.localScale.z);
            //transform.position += new Vector3(0.02f, 0, 0);
        }


        Shoot();
    }

    void Shoot()
    {
        //direction = (mousePos - new Vector2(transform.position.x, transform.position.y)).normalized;
        direction = (mousePos).normalized;
        transform.right = direction;

        if (timer != 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
            }
        }
        if (Input.GetButton("Fire1"))
        {

            /*
            if((x>0 && y>0 && y < x) || (x>0 && y<0 && -y < x))
            {
                Camera.main.transform.position += new Vector3(3f, 0, 0);
            }
            else if((x>0 && y>0 && y>x)||(x<0 && y>0 && y > -x))
            {
                Camera.main.transform.position += new Vector3(0, 3f, 0);
            }
            else if ((x < 0 && y > 0 && y < -x) || (x < 0 && y < 0 && -y < -x))
            {
                Camera.main.transform.position += new Vector3(-3f, 0, 0);
            }
            else if ((x < 0 && y < 0 && -y > -x) || (x > 0 && y < 0 && -y > x))
            {
                Camera.main.transform.position += new Vector3(0, -3f, 0);
            }
            */


            if (timer == 0)
            {
                Fire();
                timer = Interval;
            }
        }
    }

    void Fire()
    {
        //animator.SetTrigger("Shoot");

        //GameObject bullet = Instantiate(bulletPrefab, rootPos.position, Quaternion.identity);
        GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab); 

        bullet.transform.position = bulletPos.position;
        bullet.transform.rotation = headPos.rotation;


        //current camera bullet fix
        if (x > 0 && y > 0 && x > y) //1
        {
            direction = new Vector2(direction.x, direction.y - 0.06f);
        }
        else if (x > 0 && y > 0 && x < y) //2
        {
            direction = new Vector2(direction.x, direction.y + 0.08f);
        }
        else if (x < 0 && y > 0 && -x < y) //3
        {
            direction = new Vector2(direction.x, direction.y + 0.175f);
        }
        else if (x < 0 && y > 0 && -x > y) //4
        {
            direction = new Vector2(direction.x, direction.y + 0.025f);
        }
        else if (x < 0 && y < 0 && -x > -y) //5
        {
            direction = new Vector2(direction.x, direction.y - 0.05f);
        }
        else if (x < 0 && y < 0 && -x < -y) //6
        {
            direction = new Vector2(direction.x, direction.y - 0.05f);
        }
        else if (x > 0 && y < 0 && x > -y) //7
        {
            direction = new Vector2(direction.x, direction.y - 0.1f);
        }
        else if (x > 0 && y < 0 && x < -y) //8
        {
            direction = new Vector2(direction.x - 0.08f, direction.y - 0.125f);
        }
        
        


        float angle = Random.Range(-5f, 5f);
        //float angle = Random.Range(0f, 0f);
        bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(angle, Vector3.forward) * direction); //!!!

        //Instantiate(shell, rootPos.position, rootPos.rotation);
        GameObject shell = ObjectPool.Instance.GetObject(shellPrefab);
        shell.transform.position = rootPos.position;
        shell.transform.rotation = rootPos.rotation;
    }
}
