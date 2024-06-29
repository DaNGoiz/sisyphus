using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    /*
    public string monsterName;
    public float maxHealth;
    public float health;
    public float basicDamage;
    public float range;
    public Collider2D spotting;
    public PlayerController target;
    //public float armor; ??????????????????????????

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.GetMask(LayerName.player))
        {
            Vector3 dirVector = collision.transform.position - transform.position;
            if (Vector3.Angle(transform.rotation.eulerAngles, dirVector) < 70f)
            {
                RaycastHit2D ray2D = Physics2D.Raycast(transform.position, dirVector, dirVector.magnitude, 
                    LayerMask.GetMask(LayerName.obstacle,LayerName.interactive));
                if (!ray2D)
                {
                    target = collision.GetComponent<PlayerController>();
                }
            }
        }
    }
    public void Hurt(float value, GameObject from)
    {
        health -= value;
        if (health < 0)
        {
            health = 0;
            Die();
            return;
        }
        if (from.GetComponent<PlayerController>())
        {
            target = from.GetComponent<PlayerController>();
        }
    }
    public void Die()
    {
    }
    public void Spot()
    {
        if (target != null)
        {

        }
    }
    */
}
