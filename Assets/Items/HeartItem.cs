using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Heartburn", menuName = "Assets/Items/Heartburn")]
public class HeartItem : ItemPickup
{
   
    public override void OnPickup(Player player)
    {
       PlayerControls playerMovement = player.GetComponent<PlayerControls>();
        playerMovement.dashdelay -= 0.1f;
    }

}
