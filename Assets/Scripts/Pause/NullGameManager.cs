

public class NullGameManager : IGameManager
{

    public bool isPaused => true;

   // bool IGameManager.isPaused { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public void PauseGame()
    {

    }

    public void ResumeGame()
    {
        
    }
}
