using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FailedScreen : MonoBehaviour
{
    public GameObject failedPanel;
    // Start is called before the first frame update

    public Camera mainCamera;
    // Update is called once per frame
    void Update()
    {
        if (GameManager.getInstance().State == GameState.Lost)
        {
            failedPanel.SetActive(true);
        }
    }
    
    public void RestartGame()
    {
        SceneManager.LoadSceneAsync("Level_1");
        GameManager.getInstance().State = GameState.Playing;
        
    }
    
    public void GoToMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
        GameManager.getInstance().State = GameState.Menu;
    }
    
     public void LoadLevel_2_Game()
        {
            SceneManager.LoadSceneAsync("Level_2");
            GameManager.getInstance().State = GameState.Playing;
            
        }
}
