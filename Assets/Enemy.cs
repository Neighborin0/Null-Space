using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 100;
    public float currentHealth;
    public float speed;
    public float knockbackforce;
    public Joystick controller;
    public bool DropsMoney = true;
    public float MoneyAmountToDrop;
    public GameObject coin;
   // public static bool RoomIsCleared = false;
    void Start()
    {
        currentHealth = maxHealth;
    }
    void OnDestroy()
    {
      Room room = GameObject.Find("Room").GetComponent<Room>();
      Enemy enemy = base.GetComponent<Enemy>();
      room.activeEnemies.Remove(enemy);
        if (DropsMoney && !room.IsClear)
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            MoneyAmountToDrop = UnityEngine.Random.Range(1, 10);
            for (int i = 0; i < MoneyAmountToDrop; i++)
            {
                Instantiate(coin, enemy.transform.position, enemy.transform.rotation);
                Rigidbody2D coinbody = coin.GetComponent<Rigidbody2D>();
                coinbody.AddForce(new Vector2(0, 10));
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {
            Health playerhealth = collider2D.GetComponent<Health>();
            if (!playerhealth.IsInvulnerable)
            {
                playerhealth.TakeDamage(1f);
                playerhealth.ApplyKnockBack(1000f, 600f);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

   
    void Die()
    {
        Destroy(base.gameObject);
    }

}
