using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveBackAndForthBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D enemy;
    public float EnemySpeed = 10;
    [SerializeField] private LayerMask M_WhatIsWall;
    public Transform frontcheck;
    bool IsTouchingFront;
    float checkRadius = .2f;
   
    // Update is called once per frame
    void Update()
    {
        enemy.AddForce(new Vector2(EnemySpeed, 0f));
        IsTouchingFront = Physics2D.OverlapCircle(frontcheck.position, checkRadius, M_WhatIsWall);
        if (IsTouchingFront)
        {
            transform.Rotate(0f, 180f, 0f);
            EnemySpeed = EnemySpeed * -1f;
        }
    }

    
}
