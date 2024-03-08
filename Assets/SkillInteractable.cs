using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInteractable : MonoBehaviour
{
    public SkillsBase skill;
    public SpriteRenderer rend;
    private bool HasBeenInteractedWith = false;
    private static SkillInteractable instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            skill = Database.GetRandomSkill();
            BecomeRandomSkill();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (!HasBeenInteractedWith)
        {
            HasBeenInteractedWith = true;
            if (Player.IsPlayer(collider2D))
            {
                if (skill != null)
                {
                    Player player = collider2D.GetComponent<Player>();
                    NotificationDoer notification = GameObject.Find("Control").GetComponent<NotificationDoer>();
                    notification.PopUp(skill.SkillName + "\n" + skill.SkillDescription, skill.SkillIcon);
                    for (int i = 0; i < player.skillSlots.Count; i++)
                    {
                        if (player.skillSlots[i].mySkill == null)
                        {
                            player.skillSlots[i].mySkill = skill;
                            player.skillSlots[i].Init(skill, player.gameObject);        
                            gameObject.SetActive(false);
                            break;
                        }
                        for (int j = 0; j < player.skillSlots.Count; j++)
                        {
                            if (player.skillSlots[j].mySkill != null)
                            {
                                player.skillSlots[3].mySkill = null;
                                //Debug.Log("Skill has been destroyed");
                                break;
                            }
                        }

                    }

                }
            }
        }
    }
    private void BecomeRandomSkill()
    {
        rend.sprite = skill.SkillIcon;
        //Debug.Log(player.skillSlots.Count);
        //Debug.Log(player.skillSlots[0].mySkill.SkillName);
        //Debug.Log(skill.SkillName);
    
    }
}
