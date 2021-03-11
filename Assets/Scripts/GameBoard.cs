using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{

    private static int boardWidth = 28;
    private static int boardHeight = 36;

   // Getting the position for each object on the board
    public GameObject[,] board = new GameObject[boardWidth, boardHeight];
    // Start is called before the first frame update
    void Start()
    {
        Object[] objects = GameObject.FindObjectsOfType(typeof(GameObject));
        
        foreach(GameObject o in objects)
        {

            Vector2 pos = o.transform.position;

            //We don't store the position of our main charactes,objects and pellets
            if(o.name != "PacMan" && o.name != "Pellets" && o.name != "Nodes" && o.name != "Maze" && o.name != "NonNodes" && o.tag != "Ghost" && o.tag != "ghostHome")
            {
                board[(int)pos.x,(int)pos.y] = o;
            } else {
             //   Debug.Log("Found PacMan at: " + pos);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
