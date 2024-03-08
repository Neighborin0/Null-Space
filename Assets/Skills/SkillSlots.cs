using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class SkillSlots : MonoBehaviour
{
    public SkillsBase mySkill;
    public Image rend;
    [SerializeField] private Player weaponHolder;
    private float coolDownDuration;
    private float nextReadyTime;
    public string skillbuttonname;
    private float coolDownTimeLeft;


   public void Awake()
    {
        Init(mySkill, weaponHolder.gameObject);
    }


    public void Init(SkillsBase selectedAbility, GameObject weaponHolder)
    {
        if (mySkill != null)
        {
            mySkill = selectedAbility;
            coolDownDuration = mySkill.CoolDown;
            mySkill.Init(weaponHolder);
            //AbilityReady();
        }
    }
    void Update()
    {
        if (mySkill != null)
        {
            bool coolDownComplete = (Time.time > nextReadyTime);
            if (coolDownComplete)
            {
                if (Input.GetButton(skillbuttonname) && PlayerControls.CanInput)
                {
                    ButtonTriggered();
                }
            }
            else
            {
                CoolDown();
            }
            if (mySkill.SkillIcon != null && rend != null)
            {
                rend.sprite = mySkill.SkillIcon;
            }
        }
       
    }

    //private void AbilityReady()
    //{
    //    coolDownTextDisplay.enabled = false;
    //    darkMask.enabled = false;
    //}

    private void CoolDown()
    {
        coolDownTimeLeft -= Time.deltaTime;
        float roundedCd = Mathf.Round(coolDownTimeLeft);
       
    }

    private void ButtonTriggered()
    {
        if (mySkill != null)
        {
            nextReadyTime = coolDownDuration + Time.time;
            coolDownTimeLeft = coolDownDuration;
            mySkill.ActivateSkill();
        }
        else
        {
            Debug.Log("uh dude there's no ability here");
        }
    }

}
