using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public GameObject targetObject;
    
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
    
    

    // Public variable to adjust rotation speed in the Unity Editor
    public float rotationSpeed = 50f;

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

