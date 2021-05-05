using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Paused : MonoBehaviour
{
    bool isPaused_ = false;
    public PacMan pacMan;
    
    

    public GameObject pauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused_ == false){

            ServiceLocator.GetGameManager().PauseGame();
            
            isPaused_ = true;
            

            }else{
            pauseMenuUI.SetActive(false);
            ServiceLocator.GetGameManager().ResumeGame();
            isPaused_ = false;
            
                
           
            }
        }
       
    }

    public void SaveGame()
    {
        SaveSystem.SavePlayer(pacMan);
        SceneManager.LoadScene("GameMenu");

    }

    public void MainMenu()
    {
         SceneManager.LoadScene("GameMenu");
    }
    private void OnGUI()
    {
        if(isPaused_ == false)
        {
            pauseMenuUI.SetActive(true);
          isPaused_ = true;
        }
        else
        {
            pauseMenuUI.SetActive(false);
             isPaused_ = false;
    
        }

    }
    
}
