using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBoard : MonoBehaviour
{

    private static int boardWidth = 28;
    private static int boardHeight = 36;

    public int totalPellets = 0;
    public int score = 0;
    public int pacManLives = 3;

    public Text Score;


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
            if(o.name != "PacMan" && o.name != "Pellets" && o.name != "Nodes" && o.name != "Maze" && o.name != "NonNodes" && o.tag != "Ghost" && o.tag != "ghostHome" && o.name != "Canvas" && o.name != "scoreText" && o.name != "Score" && o.name != "SaveButton" && o.name !="Text" && o.name !="PauseMenu" && o.name !="Pop Ups" && o.name !="Pop Up01" && o.name != "Tutorial Manager"&& o.name !="Pop Up02"&& o.name !="Pop Up03"&& o.name !="Pop Up04" && o.name !="Pop Up05" && o.name !="Pop Up06")
            {
                if(o.GetComponent<Tile> () != null)
                {
                    if(o.GetComponent<Tile>().isPellet || o.GetComponent<Tile>().isEnergizer) 
                    {
                        totalPellets++;
                    }
                }

                board[(int)pos.x,(int)pos.y] = o;
            } else {
             //   Debug.Log("Found PacMan at: " + pos);
            }

        }
    }

    public void Restart() 
    {
        pacManLives -= 1;

        GameObject pacMan = GameObject.Find("PacMan");
        pacMan.transform.GetComponent<PacMan>().Restart();
        
        GameObject [] o = GameObject.FindGameObjectsWithTag("Ghost");

        foreach(GameObject ghost in o)
        {
            ghost.transform.GetComponent<Ghost>().Restart();
        }
        if(pacManLives == 0)
        {
            SceneManager.LoadScene("GameMenu");
            Start();
        }
    }



    

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
        endGame();
        
    }

    void UpdateUI()
    {
        Score.text = score.ToString();
    }

    public void endGame()
    {
        if(score == 2340)
        {
            SceneManager.LoadScene("GameMenu");
        }
    }
}
