using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Failed : MonoBehaviour
{
    // Start is called before the first frame update
    public void RestartGame()
    {
        SceneManager.LoadSceneAsync("Level_1");
    }
    
    public void GoToMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
}
