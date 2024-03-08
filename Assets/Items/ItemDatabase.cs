using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemDatabase", menuName = "Assets/ItemDatabases/ItemDatabase")]
public class ItemDatabase : ScriptableObject
{
    public List<ItemPickup> items;
}
