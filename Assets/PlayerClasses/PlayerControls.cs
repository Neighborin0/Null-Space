using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public Joystick controller;
    public float runspeed = 60f;
    public float dashspeed = 2000f;
    float horizontalmove = 0f;
    bool HasJumpedBefore = false;
    bool HasDoubleJumped = false;
    public float NumOfJumps = 0f;
    public float MaxNumOfJumps = 1f;
    public float dashdelay = 0.5f;
    private float m_lastUsedTime;
   // private SkillsBase skill;
    public Player player;
    public static bool CanInput = true;
    public static bool FreezePlayer = false;
    public Animator anim;
    public float verticalaim;


    // Update is called once per frame
    public void Update()
    {

        //Gets input

        if (horizontalmove == 0)
            anim.SetBool("IsRunning", false);
        else
            anim.SetBool("IsRunning", true);

        if (FreezePlayer)
        {
            horizontalmove = 0;
        }
        if (CanInput)
        {
            horizontalmove = Input.GetAxisRaw("Horizontal") * runspeed;
            if (Input.GetButtonDown("Dash") && Time.realtimeSinceStartup - m_lastUsedTime > dashdelay)
            {
                if (controller.m_FacingRight)
                {
                    controller.m_Rigidbody2D.AddForce(new Vector2(1 * dashspeed, 0f));
                }
                else
                {
                    controller.m_Rigidbody2D.AddForce(new Vector2(-1 * dashspeed, 0f));
                }
                StartCoroutine(DashFreeze());
                m_lastUsedTime = Time.realtimeSinceStartup;
            }
            if (Input.GetButtonDown("Pause"))
            {
                if (Time.timeScale != 0)
                {
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = 1;
                }
            }
           
            if (Input.GetButtonDown("Jump") && controller.m_Grounded)
            {
                HasJumpedBefore = true;
            }
            else if (Input.GetButtonDown("Jump") && NumOfJumps < MaxNumOfJumps)
            {
                HasDoubleJumped = true;
                NumOfJumps += 1;
            }
          
        }
        verticalaim = Input.GetAxisRaw("Vertical");
    }

    private IEnumerator DashFreeze()
    {
        PlayerControls.CanInput = false;
        yield return new WaitForSeconds(0.24f);
        PlayerControls.CanInput = true;
    }

    //public void ActivateSkill()
    //{

    //    skill.Skill();
    //}


    void FixedUpdate()
    {
        //moves character
        controller.Move(horizontalmove * Time.fixedDeltaTime, false, HasJumpedBefore, HasDoubleJumped);
        //Debug.Log(HasDoubleJumped);
        HasJumpedBefore = false;
        HasDoubleJumped = false;
        if (controller.m_Grounded)
        {
          NumOfJumps *= 0;
        }
        if (controller.WallSliding)
        {
            NumOfJumps *= 0;
        }
     
    }
}
