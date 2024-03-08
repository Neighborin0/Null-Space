using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class ShopItem : Interactable
{
    public ItemPickup item;
    public SpriteRenderer rend;
    private static ShopItem instance;
    private int price;
    public Sprite coin;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            item = Database.GetRandomItem();
            BecomeRandomItem();
            DontDestroyOnLoad(gameObject);
            price = UnityEngine.Random.Range(1, 10);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public override void OnInteract()
    {
        PlayerControls.CanInput = true;
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if(player.Money >= price)
        {
            if (item != null)
            {
                item.OnPickup(player);
                NotificationDoer notification = GameObject.Find("Control").GetComponent<NotificationDoer>(); 
                notification.PopUp(item.name + "\n" + item.longdesc, item.itemsprite);
                player.Money -= price;
                gameObject.SetActive(false);
            }
        }

    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        NotificationDoer notification = GameObject.Find("Control").GetComponent<NotificationDoer>();
        notification.PopUp(price.ToString(), null);
    }

    private void BecomeRandomItem()
    {
        rend.sprite = item.itemsprite;
    }
}
