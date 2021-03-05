using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : IGameManager
{
    private bool _isPaused = false;
    public bool isPaused => _isPaused;
    public void PauseGame()
    {
        _isPaused = !isPaused;
    }
}
