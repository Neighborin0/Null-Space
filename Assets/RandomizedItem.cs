using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class RandomizedItem : MonoBehaviour
{
    public ItemPickup item;
    public SpriteRenderer rend;
    private bool HasBeenInteractedWith = false;
    private static RandomizedItem instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            item = Database.GetRandomItem();
            BecomeRandomItem();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (!HasBeenInteractedWith)
        {
            HasBeenInteractedWith = true;
            if (Player.IsPlayer(collider2D))
            {
                if (item != null)
                {
                   
                    Player player = collider2D.GetComponent<Player>();
                    item.OnPickup(player);
                    NotificationDoer notification = GameObject.Find("Control").GetComponent<NotificationDoer>();
                    notification.PopUp(item.name + "\n" + item.longdesc, item.itemsprite);
                    gameObject.SetActive(false);
                   // DontDestroyOnLoad(gameObject);
                    //notification.animator.SetTrigger("PopUpAnimationPop");
                }
            }
        }
    }

    private void BecomeRandomItem()
    {
        rend.sprite = item.itemsprite;
    }
}
