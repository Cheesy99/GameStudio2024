using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        GameManager.getInstance().State = GameState.Menu;
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Level_1");
        GameManager.getInstance().State = GameState.Playing;
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}  

