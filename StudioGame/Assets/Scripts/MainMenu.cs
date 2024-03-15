using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject targetObject;
    public float rotationSpeed = 20f;
    private string onLevel;

    private void Awake()
    {
        GameManager.getInstance().State = GameState.Menu;
        onLevel = "Level_1";
        // Ensure the targetObject is set and active
        if (targetObject != null)
        {
            targetObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Target object is not set in MainMenu script.");
        }
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

    void Update()
    {
        // Rotate the targetObject around its local up axis (usually the Y axis)
        if (targetObject != null)
        {
            targetObject.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("Target object is not set in RotateObject script.");
        }
    }

    public void HandleInputData(int var)
    {
        onLevel = var switch
        {
            0 => "Level_1",
            1 => "Level_2",
            2 => "Level_3",
            _ => onLevel
        };
    }
}