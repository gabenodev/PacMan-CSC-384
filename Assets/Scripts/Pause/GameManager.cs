using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : IGameManager
{
    public bool _isPaused = false;
    
    public bool isPaused => _isPaused;
    

    public void PauseGame()
    {
        _isPaused = !isPaused;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        _isPaused = isPaused;
        Time.timeScale = 1f;
    }

}
