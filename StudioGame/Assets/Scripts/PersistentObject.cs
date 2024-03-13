using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentObjects : MonoBehaviour
{
    public GameObject canvas;
    public GameObject plane;
    public GameObject camera;
    public GameObject fireController;
    public GameObject waterController;
    public GameObject gameManager;// Add all your controllers here

    private static PersistentObjects instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
}
