using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyTargetingRadius : MonoBehaviour
{
    public Enemy enemy;
    private Player player;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void FixedUpdate()
    {
        if (player != null)
        {
            //Debug.Log("open up dumptruck");
            float step = 1 * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, player.gameObject.transform.position, step);
            //Debug.Log(step);
        }
    }
}
