using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedyShoes", menuName = "Assets/Items/SpeedyShoes")]
public class SpeedyShoes : ItemPickup
{
   
    public override void OnPickup(Player player)
    {
        PlayerControls playerMovement = player.GetComponent<PlayerControls>();
        playerMovement.runspeed += 20;
    }

}
