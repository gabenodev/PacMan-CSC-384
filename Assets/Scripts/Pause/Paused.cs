using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paused : MonoBehaviour
{

    private bool LabelEnabled = true;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(ServiceLocator.GetGameManager().isPaused == false){

            ServiceLocator.GetGameManager().PauseGame();

            }else{

            ServiceLocator.GetGameManager().ResumeGame();
          //  ServiceLocator.GetGameManager().isPaused = false;
        
            }
        }

       
    }
    private void OnGUI()
    {
        if(ServiceLocator.GetGameManager().isPaused)
        {
            GUI.enabled = LabelEnabled;
            GUI.Label(new Rect(10,10,100,20), "Paused");
        }
        else
        {
            GUI.enabled = true;
        }

    }
}
