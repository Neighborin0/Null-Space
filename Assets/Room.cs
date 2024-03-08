using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviour
{
    public List<Enemy> activeEnemies;
    public List<GameObject> objectsToDestroyOnLoad;
    private GameObject doorpoint;
    private GameObject doorpoint2;
    public GameObject door;
    public bool IsClear = false;
    void Update()
    {   
       if(activeEnemies.Count == 0)
        {
            RoomClear();
            IsClear = true;
        }
    }

    public void RoomClear()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Door").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("Door")[i]);
            Debug.Log("OPEN THE FACKIN DOORS");
        }
    }
    public void OnEnter()
    {
        // Debug.Log("Room has been entered");


            if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            doorpoint = GameObject.FindGameObjectWithTag("SceneExit");
            doorpoint2 = GameObject.FindGameObjectWithTag("SceneTransition");
            Vector3 offset = new Vector3(1.3f, 1.5f, 0);
            Vector3 offset2 = new Vector3(-1.3f, 1.5f, 0);
            Debug.Log("Lock da doors");

            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++)
            {
                
                Enemy enemy = GameObject.FindGameObjectsWithTag("Enemy")[i].GetComponent<Enemy>();
                if (IsClear)
                {
                    Destroy(enemy.gameObject);
                }
                else
                {
                    activeEnemies.Add(enemy);
                }
                Debug.Log(activeEnemies.Count);
            }
            Instantiate(door, doorpoint.transform.position + offset, doorpoint.transform.rotation);
            Instantiate(door, doorpoint2.transform.position + offset2, doorpoint2.transform.rotation);
        }
            
    }
  
}
