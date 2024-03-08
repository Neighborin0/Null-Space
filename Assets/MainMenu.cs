using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Transform spawnpoint;
    public GameObject player;
    public List<int> availableScenes;
    public List<int> playedScenes;

    public void PlayGame()
    {
        PlayerPrefs.SetFloat("Health", Health.currentHealth);
        PlayerPrefs.SetFloat("MaxHealth", Health.maxHealth);
        PlayerControls.CanInput = true;
        //ItemInitalizer.InitItems();
        playedScenes.Add(1);
        SceneManager.LoadScene(1);
        SceneManager.sceneLoaded += OnSceneLoaded;
       
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        spawnpoint = GameObject.Find("RespawnPoint").transform;
        Instantiate(player, spawnpoint.position, spawnpoint.rotation);
        Debug.Log(spawnpoint.transform.position);
        Debug.Log(player.gameObject.transform.position);
        SceneManager.sceneLoaded -= OnSceneLoaded;
        RandomizeSceneOrder();
    }

    private void RandomizeSceneOrder()
    {
        int MaXNumOfAvailableScenes = 4;
        int MinNumOfAvailableScenes = 2;
        while (playedScenes.Count < MaXNumOfAvailableScenes + 1)
        {
            int sceneToChoose = UnityEngine.Random.Range(MinNumOfAvailableScenes, MaXNumOfAvailableScenes);
            //availableScenes.RemoveAt(sceneToChoose);
            playedScenes.Add(sceneToChoose);
        }
        
    }
}
