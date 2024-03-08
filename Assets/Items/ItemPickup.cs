using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Assets/Item")]
public class ItemPickup : ScriptableObject
{
    public int itemid;
    public string ItemName;
    public string shortdesc;
    [TextArea]
    public string longdesc;
    public Sprite itemsprite;


    public virtual void OnPickup(Player player)
    { 
    
    }
   
}
