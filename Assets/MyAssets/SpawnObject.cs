using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public Sprite[] objects;
    public GameObject tile;
    public GameObject tile2;
    public GameObject tile3;
    public GameObject EnterPoint;
    public GameObject ExitPoint;
    public GameObject RoomEnter;
    public GameObject RoomExit;
    public GameObject background;

    private void Awake()
    {
        int rand = Random.Range(0, objects.Length);
        GenerateRoomFromPicture(rand);
        //camera.gameObject.transform.position = GameObject.FindGameObjectWithTag("Player").gameObject.transform.position;
    }

    private void GenerateRoomFromPicture(int rand)
    {
        int width = objects[rand].texture.width;
        int height = objects[rand].texture.height;
        Vector3 BackGroundPos = new Vector3(objects[rand].texture.width / 2, objects[rand].texture.height / 1.2f, 0);
        Instantiate(background, BackGroundPos, Quaternion.identity);
        Debug.Log(BackGroundPos);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GetTileForColor(objects[rand].texture.GetPixel(x, y), x, y, width, height);
            }
        }
    }

    private void GetTileForColor(Color32 color, int x, int y, int width, int height)
    {
        var camera = GameObject.Find("MainCam").GetComponent<CameraBehavior>();
        Vector3 tilePOS = new Vector3(x, y, 1);
        int halfWidth = (width / 2);
        if (color == Color.black)
        {
            Instantiate(tile, tilePOS, Quaternion.identity);
        }
        if (color == Color.white)
        {
            //Debug.Log("enter here ya idiot");
            Instantiate(EnterPoint, tilePOS, Quaternion.identity);

        }
        if (color == Color.magenta)
        {
            //Debug.Log("get out!!!");
            Instantiate(ExitPoint, tilePOS, Quaternion.identity);
        }
        if (color == Color.red)
        {
            //Debug.Log("get out!!!");
            Instantiate(RoomExit, tilePOS, Quaternion.identity);
            camera.MinX = tilePOS.x + 15;
        }
        if (color == Color.blue)
        {
           // Debug.Log("get in!!!");
            Instantiate(RoomEnter, tilePOS, Quaternion.identity);
            camera.MaxX = tilePOS.x - 15;
        }
        if (color == Color.cyan)
        {
            Instantiate(tile2, tilePOS, Quaternion.identity);
        }
        if (color == Color.green)
        {
            Instantiate(tile3, tilePOS, Quaternion.identity);
        }
    }
}
