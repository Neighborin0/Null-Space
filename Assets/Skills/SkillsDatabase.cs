using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SkillsDatabase", menuName = "Assets/ItemDatabases/SkillsDatabase")]
public class SkillsDatabase : ScriptableObject
{
    public List<SkillsBase> skills;
}
