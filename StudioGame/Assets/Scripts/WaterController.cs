using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaterController : MonoBehaviour
{
    
    public static WaterController Instance { get; private set; }

    public Slider waterBar;
    public WaterGun gun;
    public WaterBomb waterBomb;
    private float  _waterLevel;
    

    private void Awake()
    {
        string currentScene = SceneManager.GetActiveScene().name; 
        if (Instance != null) return;
            _waterLevel = 100f; 
            if (currentScene == "Level_3")
            {
                _waterLevel = 5f;
                waterBar.value = _waterLevel; // Set a different initial water level for Scene3
            }
            else
            {
                _waterLevel = 100f; // Set the initial water level to 100 for other scenes
            }
        Instance = this;
    }
    

    public float getWaterLevel()
    {
        return _waterLevel;
    }
    public void GunShot()
    {
        _waterLevel -= 0.1f;// Decrease the water level
        waterBar.value = _waterLevel;
    }

    public void BombDropped()
    {
        _waterLevel -= 0.1f;
        waterBar.value = _waterLevel;
    }

    private void Update()
    {
        if(_waterLevel <= 0)
            GameManager.getInstance().State = GameState.Lost;
    }
    
        public void FillWater(float amount)
        {
            _waterLevel += amount; // Increase the water level
            _waterLevel = Mathf.Min(_waterLevel, 100f); // Ensure the water level does not exceed 100

            waterBar.value = _waterLevel; // Update the water bar value
        }
}
