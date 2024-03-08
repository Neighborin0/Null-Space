using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wax Wings", menuName = "Assets/Items/Wax Wings")]
public class WaxWings : ItemPickup
{
    public override void OnPickup(Player player)
    {
        PlayerControls playerMovement = player.GetComponent<PlayerControls>();
        playerMovement.MaxNumOfJumps++;
    }
   
}
