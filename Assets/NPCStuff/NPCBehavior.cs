using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavior : Interactable
{
    private Color textcolor;
    private bool InConversation = false;
    private string[] sentences = new string[]
        {
            "",
            "Hey Hey Bub.",
            "I just wanted to say, I love you. :)",
            "Nah, just kidding fuck you kid ahahhahahahahaa."
        };

    public override void OnInteract() 
    {
        Color color = Color.white;
        PlayerControls.CanInput = false;
        PlayerControls.FreezePlayer = true;
        NotificationDoer notification = GameObject.Find("Control").GetComponent<NotificationDoer>();
        notification.DoNPCText(sentences, color, 0.05f);

    }
}
