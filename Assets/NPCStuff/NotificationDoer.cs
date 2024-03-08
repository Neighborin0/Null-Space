using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class NotificationDoer : MonoBehaviour
{
    public GameObject popupbox;
    public Image itemsprite;
    public TMP_Text popup;
    private Vector3 scale;
    //NPC stuff
    private int index;

    void Awake()
    {
        popup.text = "";
    }
    public void DoNPCText(string[] text, Color textColor, float textSpeed)
    {
        if (popup.text == text[index])
        {
            itemsprite.transform.position = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            if (index < text.Length - 1)
            {
                index++;
                popup.text = "";
                popup.alignment = TextAlignmentOptions.MidlineLeft;
                popupbox.SetActive(true);
                StartCoroutine(TypeNPCDialouge(text, textColor, textSpeed));
            }
            else
            {
                // Debug.Log("Say something you idiot!");
                // Debug.Log(text.Length);
                popup.text = "";
                PlayerControls.CanInput = true;
                PlayerControls.FreezePlayer = false;
                popupbox.SetActive(false);
                index = 0;
            }
        }
    }

    private IEnumerator TypeNPCDialouge(string[] text, Color textColor, float textSpeed)
    {
        Debug.Log(index);
        foreach (char letter in text[index].ToCharArray())
        {
            popup.text += letter;
            yield return new WaitForSeconds(textSpeed); 
        }

    }

    public void PopUp(string text, Sprite sprite)
    {
        //popupbox.SetActive(true);
         
        popupbox.SetActive(true);
        scale = new Vector3(80, 79, -1);
        itemsprite.sprite = sprite;
        popupbox.transform.localScale = scale;
        popup.text = text;
        //animator.SetTrigger("PopUpAnimationPop");
        StartCoroutine(RevertScale());
    }

    private IEnumerator RevertScale()
    {
        yield return new WaitForSeconds(5f);
        scale = new Vector3(0, 0, 0);
        popupbox.transform.localScale = scale;
        popupbox.SetActive(false);
    }
}
