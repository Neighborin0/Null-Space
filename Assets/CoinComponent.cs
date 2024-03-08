using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinComponent : MonoBehaviour
{
    private bool HasBeenInteractedWith = false;
 
        void OnTriggerEnter2D(Collider2D collider2D)
        {
        
         if (!HasBeenInteractedWith)
        {
            if (Player.IsPlayer(collider2D))
            {
                Player player = collider2D.GetComponent<Player>();
                player.Money++;
                Destroy(gameObject);
                HasBeenInteractedWith = true;
            }
           
        }
        
    }
}
