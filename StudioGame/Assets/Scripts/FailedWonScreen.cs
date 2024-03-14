using UnityEngine;
using UnityEngine.SceneManagement;


public class FailedWonScreen : MonoBehaviour
{
    public GameObject failedPanel;

    public GameObject WonPanel;
    // Start is called before the first frame update
    
    void Update()
    {
        if (GameManager.getInstance().State == GameState.Lost)
        {
            failedPanel.SetActive(true);
        }

        if (GameManager.getInstance().State == GameState.Won)
        {
            WonPanel.SetActive(true);
        }
    }
    
    public void RestartGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadSceneAsync(currentSceneName);
        GameManager.getInstance().State = GameState.Playing;
    }
    
    public void GoToMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
        GameManager.getInstance().State = GameState.Menu;
    }

    public void LoadLevel_2()
    {
        SceneManager.LoadScene("Level_2");
    }

    public void LoadLevel_3()
    {
        SceneManager.LoadScene("Level_3");
    }
}
