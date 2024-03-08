using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public ItemDatabase items;
    public SkillsDatabase skills;
    private static Database instance;
     void Awake()
    {
      
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static ItemPickup GetItemById(int id)
    {
        foreach(ItemPickup item in instance.items.items)
        {
            if(item.itemid == id)
            {
                return item;
            }     
        }
        return null;
    }

    public static SkillsBase GetRandomSkill()
    {
        int id = UnityEngine.Random.Range(0, instance.skills.skills.Count);
        foreach (SkillsBase skill in instance.skills.skills)
        {
            if (skill.SkillID == id)
            {
                return skill;
            }
        }
        return null;
    }

    public static ItemPickup GetRandomItem()
    {
        int id = UnityEngine.Random.Range(0, instance.items.items.Count);
        foreach (ItemPickup item in instance.items.items)
        {
            if (item.itemid == id)
            {
                return item;
            }   
        }
        return null;
    }

}
