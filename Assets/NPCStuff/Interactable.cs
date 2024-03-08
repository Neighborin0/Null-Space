using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private bool CanBeInteractedWith;
    bool axisInUse = false;
    [SerializeField] private LayerMask WhatIsPlayer;
    float checkRadius = 1f;
   
    void Update()
    {
        CanBeInteractedWith = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, checkRadius, WhatIsPlayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
               // Debug.Log("TALK TO ME PLEASE");
                CanBeInteractedWith = true;
            }
        }
        if (Input.GetAxisRaw("Vertical") == 1 && CanBeInteractedWith)
        {
            if (!axisInUse)
            {
                PlayerControls.CanInput = false;
                OnInteract();
                axisInUse = true;
            }
        }
        else
        {
            axisInUse = false;
        }
      
    }


    //void OnTriggerEnter2D(Collider2D collider2D)
    //{
     
    //    if (Player.IsPlayer(collider2D))
    //    {
    //        CanBeInteractedWith = true;
    //    }
    //    else
    //    {
    //        CanBeInteractedWith = false;
    //    }
    //}
   
    public abstract void OnInteract();
    
}
