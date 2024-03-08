using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Slash", menuName = "Assets/Skills/Slash")]
public class Slash : SkillsBase
{
    public float BulletSpeed = 20f;
    public GameObject bullet;
    public Transform bulletSpawn;
    private Vector3 offset;
    public float FacingDir;

    public override void Init(GameObject obj)
    {
        bulletSpawn = obj.transform.Find("shootpoint");
        Bullet b = bullet.GetComponent<Bullet>();
        b.range = 0.01f;
        b.damage = 7f;
    }

    public override void ActivateSkill()
    {
        if (bulletSpawn != null)
        {
            if (Input.GetAxisRaw("Vertical") != 0)
            {
                offset = new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            }
            else
            {
                offset = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            }
            Instantiate(bullet, bulletSpawn.position + offset, bulletSpawn.rotation);
        }
    }
}
