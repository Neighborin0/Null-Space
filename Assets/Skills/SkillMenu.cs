using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class SkillMenu : MonoBehaviour
{

    public List<Image> images;
    public List<SkillsBase> skills;
    public Sprite psCircle;
    public Sprite psSquare;
    public Sprite psTriangle;
    private SkillsBase reserveSkill;
    public GameObject skillUI;
    private bool IsInMenu;
    private int selectedoption = 0;
    private int min = 0;
    private int max;
    public Image whiteMask;
    bool axisInUse = false;
    private GameObject player;
    // Update is called once per frame

    void Awake()
    {
        EventSystem.current.SetSelectedGameObject(images[0].gameObject);   
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            if (Input.GetButtonDown("SkillMenu"))
            {
                if (Time.timeScale != 0.01f)
                {
                    Time.timeScale = 0.01f;
                    skillUI.SetActive(true);
                    PlayerControls.CanInput = false;
                    IsInMenu = true;
                    for (int i = 0; i < images.Count; i++)
                    {
                        if (player.skillSlots[i].mySkill != null)
                        {
                            images[i].sprite = player.skillSlots[i].mySkill.SkillIcon;
                        }
                    }

                }
                else
                {
                    Time.timeScale = 1;
                    skillUI.SetActive(false);
                    PlayerControls.CanInput = true;
                    IsInMenu = false;
                }

            }

            if (IsInMenu)
            {
                if (Input.GetButtonDown("Skill1"))
                {
                    AssignSkill(player.skillSlots[0], player);
                }
                if (Input.GetButtonDown("Skill2"))
                {
                    AssignSkill(player.skillSlots[1], player);
                }
                if (Input.GetButtonDown("Skill3"))
                {
                    AssignSkill(player.skillSlots[2], player);
                }
                if (Input.GetAxisRaw("Vertical") == 1 && selectedoption != min && !axisInUse)
                {

                    selectedoption -= 1;
                    EventSystem.current.SetSelectedGameObject(images[selectedoption].gameObject);
                    axisInUse = true;
                    StartCoroutine((SmallAxisDelay()));
                }
                else if (Input.GetAxisRaw("Vertical") == 1 && selectedoption == min && !axisInUse)
                {
                    selectedoption = max;
                    EventSystem.current.SetSelectedGameObject(images[selectedoption].gameObject);
                    axisInUse = true;
                    StartCoroutine((SmallAxisDelay()));
                }

                if ((Input.GetAxisRaw("Vertical") == -1 && selectedoption != max && !axisInUse))
                {
                    selectedoption += 1;
                    EventSystem.current.SetSelectedGameObject(images[selectedoption].gameObject);
                    axisInUse = true;
                    StartCoroutine((SmallAxisDelay()));
                }
                else if (Input.GetAxisRaw("Vertical") == -1 && selectedoption == max && !axisInUse)
                {
                    selectedoption = min;
                    EventSystem.current.SetSelectedGameObject(images[selectedoption].gameObject);
                    axisInUse = true;
                    StartCoroutine((SmallAxisDelay()));
                }

            }
            for (int i = 0; i < images.Count; i++)
            {
                if (EventSystem.current.currentSelectedGameObject == images[i].gameObject)
                {
                    images[i].sprite = whiteMask.sprite;
                }
                else
                {
                    if (player.skillSlots[i].mySkill != null)
                    {
                        images[i].sprite = player.skillSlots[i].mySkill.SkillIcon;
                        skills[i] = player.skillSlots[i].mySkill;

                    }

                }
            }
            //very shameful code, to anyone potentially reading this, please forgive me, I was young and dumb
            if (player.skillSlots[3].mySkill != null)
            {
                max = 3;
            }
            else if (player.skillSlots[2].mySkill != null)
            {
                max = 2;
            }
            else if (player.skillSlots[1].mySkill != null)
            {
                max = 1;
            }
            else if (player.skillSlots[0].mySkill != null)
            {
                max = 0;
            }
        }

    }

    private void AssignSkill(SkillSlots skillSlot, Player player)
    {
        if (skillSlot.mySkill != skills[selectedoption])
        {
            reserveSkill = skillSlot.mySkill;
            skillSlot.mySkill = skills[selectedoption];
            player.skillSlots[selectedoption].mySkill = reserveSkill;
            skillSlot.Init(skills[selectedoption], player.gameObject);
            player.skillSlots[selectedoption].Init(reserveSkill, player.gameObject);
            reserveSkill = null;
        }
    }

    private IEnumerator SmallAxisDelay()
    {
        yield return new WaitForSeconds(0.001f);
        axisInUse = false;
    }
}
