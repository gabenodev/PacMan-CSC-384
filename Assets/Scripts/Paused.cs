using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paused : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            ServiceLocator.GetGameManager().PauseGame();
        }
    }
    private void OnGUI()
    {
        if(ServiceLocator.GetGameManager().isPaused)
        {
            GUI.Label(new Rect(10,10,100,20), "Paused");
        }

    }
}
