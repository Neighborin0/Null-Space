using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public bool border;
    public float MinX;
    public float MinY;
    public float MaxX;
    public float MaxY;
    private Joystick player;

    // Update is called once per frame
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Joystick>();
    }
    void LateUpdate()
    {
        if(MaxX == 0)
        {
            MaxX = float.MaxValue;
        }

        if (player != null)
        {
            int DistanceAway = 40;
            int DistanceAwayY = 3;
            float step = 10 * Time.deltaTime;
            Vector3 PlayerPOS = player.transform.position;
            if (PlayerPOS.x > MinX && PlayerPOS.x < MaxX)
            {
                transform.position = Vector3.LerpUnclamped(transform.position, new Vector3(PlayerPOS.x + (0.1f * player.FacingDirection), PlayerPOS.y + DistanceAwayY, PlayerPOS.z - DistanceAway), step);
            }
            else
            {
                transform.position = Vector3.LerpUnclamped(transform.position, new Vector3(transform.position.x, PlayerPOS.y + DistanceAwayY, PlayerPOS.z - DistanceAway), step);
            }
        }
    }
}
