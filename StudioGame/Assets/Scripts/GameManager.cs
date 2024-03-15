using UnityEngine;
using UnityEngine.SceneManagement;

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
    
    void Update()
{
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        State = GameState.Menu;
        SceneManager.LoadSceneAsync("Menu");
    }
}
    
}


public enum GameState
{
    Playing,
    Lost,
    Won,
    Menu
    
}