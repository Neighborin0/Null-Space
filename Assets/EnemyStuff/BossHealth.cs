using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public HealthNubs healthNubs;
    public Enemy enemycontroller;
    void Start()
    {
        HealthNubs nubs = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthNubs>();
        healthNubs = nubs;
        enemycontroller = gameObject.GetComponent<Enemy>();
        healthNubs.SetMaxHealth(enemycontroller.maxHealth);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
