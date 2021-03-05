using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConstructor : MonoBehaviour
{

    private void Awake()
    {
        ServiceLocator.Init();

        IGameManager desiredGameManager = new GameManager();

        ServiceLocator.Provide(desiredGameManager);
    }
}
