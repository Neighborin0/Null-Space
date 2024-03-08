using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System;

public class SceneController : MonoBehaviour
{
    public GameObject healthbar;
    private GameObject spawnpoint;
    public GameObject MainCam;
    GameObject player;
    public bool IsEnter;
    //[SerializeField] public Transform spawnpoint;
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag == "Player")
        {
            MainCam = GameObject.Find("MainCam");
            healthbar = GameObject.Find("Healthbar");
            if(IsEnter)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                SceneManager.sceneLoaded += OnSceneEntered;
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
                SceneManager.sceneLoaded += OnSceneExited;
            }
            DontDestroyOnLoad(collider2D.gameObject);
            DontDestroyOnLoad(healthbar);
            DontDestroyOnLoad(MainCam);
            PlayerPrefs.SetFloat("Health", Health.currentHealth);
            PlayerPrefs.SetFloat("MaxHealth", Health.maxHealth);
        }
    }

    private void OnSceneEntered(Scene scene, LoadSceneMode mode)
    {
        //StartCoroutine((GetTransitionSetup()));
        player = GameObject.FindGameObjectWithTag("Player");    
        spawnpoint = GameObject.FindGameObjectWithTag("EnterPoint");
        player.gameObject.transform.position = spawnpoint.transform.position;
        var camera = GameObject.Find("MainCam").GetComponent<CameraBehavior>();
        camera.transform.position = new Vector2(camera.MinX + 2, camera.transform.position.y);
        Debug.Log(spawnpoint.transform.position);
        Debug.Log(player.gameObject.transform.position);
        SceneManager.sceneLoaded -= OnSceneEntered;
        Room room = GameObject.Find("Room").GetComponent<Room>();
        if(room != null)
        room.OnEnter();
        DontDestroyOnLoad(room);
    }
    private void OnSceneExited(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnpoint = GameObject.FindGameObjectWithTag("ExitPoint");
        player.gameObject.transform.position = spawnpoint.transform.position;
        var camera = GameObject.Find("MainCam").GetComponent<CameraBehavior>();
        camera.transform.position = new Vector2(camera.MinX - 5, camera.transform.position.y);
        Debug.Log(spawnpoint.transform.position);
        Debug.Log(player.gameObject.transform.position);
        SceneManager.sceneLoaded -= OnSceneExited;
        Room room = GameObject.Find("Room").GetComponent<Room>();
        if (room != null)
            room.OnEnter();
        DontDestroyOnLoad(room);
    }


}
