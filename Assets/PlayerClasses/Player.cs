using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
   static GameObject player;
   public Transform shootpoint;
   public float Money;
   public TMP_Text MoneyCounter;
   private Joystick controller;
   public List<SkillSlots> skillSlots;
   void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<Joystick>(); 
    }

    void Update()
    {
        MoneyCounter.text = Money.ToString();
        if (Input.GetAxisRaw("Vertical") == -1 && !controller.m_Grounded)
        {
            shootpoint.localPosition = new Vector3(0.005f, 0.345f, 0);
        }
        else if (Input.GetAxisRaw("Vertical") == 1)
        {
            shootpoint.localPosition = new Vector3(0.005f, 0.345f, 0);
        }
        else
        {
            shootpoint.localPosition = new Vector3(0.261f, 0.055f, 0);
        }
    }
    public static bool IsPlayer(Collider2D collider2D)
    {
        if(collider2D.tag == "Player")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
