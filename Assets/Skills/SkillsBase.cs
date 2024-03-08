using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillsBase : ScriptableObject
{
    public string SkillName;
    public Sprite SkillIcon;
    public float CoolDown;
    public int SkillID;
    public string SkillDescription;
   
    public abstract void Init(GameObject gameObject);
    public abstract void ActivateSkill();
   
}
