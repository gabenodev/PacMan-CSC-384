using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : IGameManager
{
    public bool _isPaused;
    public bool isPaused => _isPaused;

    
   // bool IGameManager.isPaused { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

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
