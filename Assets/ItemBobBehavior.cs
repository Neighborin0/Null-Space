using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class ItemBobBehavior : MonoBehaviour
{
    private float floatspeed = 0.001f;
    void Awake()
    {
        var aTimer = new System.Timers.Timer(1000);
        aTimer.Elapsed += Flip;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
    }
    void Update()
    {
        gameObject.transform.position += new Vector3(0, floatspeed, 0);

    }

    private void Flip(System.Object source, ElapsedEventArgs e)
    {
        floatspeed *= -1;
    }
}
