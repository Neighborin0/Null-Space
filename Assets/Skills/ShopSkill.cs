using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSkill : Interactable
{
    public SkillsBase skill;
    public SpriteRenderer rend;
    private int price;
    public Sprite coin;

    private static ShopSkill instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            skill = Database.GetRandomSkill();
            BecomeRandomSkill();
            DontDestroyOnLoad(gameObject);
            price = UnityEngine.Random.Range(1, 10);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public override void OnInteract()
    {
        PlayerControls.CanInput = true;
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (player.Money >= price)
        {
            if (skill != null)
            {
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
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        NotificationDoer notification = GameObject.Find("Control").GetComponent<NotificationDoer>();
        notification.PopUp(price.ToString(), null);
    }
    private void BecomeRandomSkill()
    {
        rend.sprite = skill.SkillIcon;
     
    }
}
