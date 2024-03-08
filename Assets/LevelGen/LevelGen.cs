using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "RoomDatabase", menuName = "Assets/ItemDatabases/RoomDatabase")]

public class RoomDatabase : ScriptableObject
{
    public List<Sprite> MushroomForestRooms;
}
