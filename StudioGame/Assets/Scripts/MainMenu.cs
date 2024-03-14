using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject targetObject;
    public float rotationSpeed = 20f;

    private void Awake()
    {
        GameManager.getInstance().State = GameState.Menu;

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
}