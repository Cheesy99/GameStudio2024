using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;

    public GameState State;

   

    private void Awake()
    {
        Instance = this;
    }

    public static GameManager getInstance()
    {
        return Instance;
    }
    
}


public enum GameState
{
    Playing,
    Lost,
    Won,
    Menu
    
}