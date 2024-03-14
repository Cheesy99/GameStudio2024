using UnityEngine;
using UnityEngine.UI;

public class WaterController : MonoBehaviour
{
    
    public static WaterController Instance { get; private set; }

    public Slider waterBar;
    public WaterGun gun;
    public WaterBomb waterBomb;
    private float  _waterLevel;

    private void Awake()
    {
        if (Instance != null) return;
        _waterLevel = 100f;
        Instance = this;
    }

    public void GunRegisterToWaterBar(WaterGun gun)
    {
        this.gun = gun;
    }
    
    public void BombRegisterToWaterBar(WaterBomb bomb)
    {
        waterBomb = bomb;
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
}
