using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;
[CreateAssetMenu(fileName = "Shoot", menuName = "Assets/Skills/Shoot")]
public class Shoot : SkillsBase
{
    public float BulletSpeed = 20f;
    public GameObject bullet;
    private Joystick controller;
    public Transform bulletSpawn;
    private Animator anim;


    public override void Init(GameObject obj)
    {
        //base.CoolDown = 0.1f;
        var player = obj.GetComponent<Player>();
        bulletSpawn = player.shootpoint;
        anim = player.GetComponent<Animator>();
        controller = obj.GetComponent<Joystick>();
        Bullet b = bullet.GetComponent<Bullet>();
        b.range = 10f;
        b.damage = 1f;
    }

    public override void ActivateSkill()
    {
        anim.Play("MarineShootForward");
        if (Input.GetAxisRaw("Vertical") == -1 && !controller.m_Grounded)
        {
            controller.m_Rigidbody2D.velocity = Vector3.zero;
            anim.Play("MarineShootUp");
        }
        else if(Input.GetAxisRaw("Vertical") == 1)
        {
            anim.Play("MarineShootUp");
        }
        else
        {
            anim.Play("MarineShootForward");
        }
        Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);

    }

  
}
