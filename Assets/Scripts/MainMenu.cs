﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
   public void playGame()
   {
       SceneManager.LoadScene("Level1");
   }

   public void loadGame()
   {
       SaveSystem.LoadPlayer();
       SceneManager.LoadScene("Level1");
   }

    public void tutorialGame()
    {
        
        SceneManager.LoadScene("Tutorial");
    }
}
