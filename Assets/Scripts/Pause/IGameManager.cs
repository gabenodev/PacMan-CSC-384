using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameManager 
{

    bool isPaused { get;}

    void PauseGame();
    void ResumeGame();
    

    

}
   
