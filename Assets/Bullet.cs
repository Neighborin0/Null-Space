using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float range = 5f;
    public float damage = 1f;
    public Rigidbody2D rb;
    private Joystick controller;
    public Transform bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<Joystick>();
        rb.velocity = transform.right * speed;    
        float verticalaim = Input.GetAxisRaw("Vertical");
        if(verticalaim == 1)
        {
            rb.velocity = transform.up * speed;
        }
        if (verticalaim == -1 && !controller.m_Grounded)
        {
            rb.velocity = (transform.up * speed) * -1;
        }
        if (verticalaim == 0)
        {
            rb.velocity = transform.right * speed; 
        }
        StartCoroutine(DestroyBullet());
    }

    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(range);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider2D)
     {
        if (collider2D.tag == "Terrain" || collider2D.tag == "Enemy")
        {
           Enemy enemyhealth = collider2D.GetComponent<Enemy>();
            if(enemyhealth != null)
            {
                enemyhealth.TakeDamage(damage);
            }
            //Debug.Log(collider2D.name);
            Destroy(gameObject);
        }
      
    }
   
}
