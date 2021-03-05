using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paused : MonoBehaviour
{
    bool isPaused_ = ServiceLocator.GetGameManager().isPaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused_ == false){

            ServiceLocator.GetGameManager().PauseGame();
            isPaused_ = true;
            

            }else{

            ServiceLocator.GetGameManager().ResumeGame();
            isPaused_ = false;
            
                
           
            }
        }

       
    }
    private void OnGUI()
    {
        if(isPaused_ == false)
        {
            GUI.Label(new Rect(10,10,100,20), "Paused");
          isPaused_ = true;
        }
        else
        {
            GUI.enabled = false;
             isPaused_ = false;
    
        }

    }
}
