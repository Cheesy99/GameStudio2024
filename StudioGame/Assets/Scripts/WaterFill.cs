using UnityEngine;

public class WaterFill : MonoBehaviour
{
    // Reference to the WaterController
    private float _fillAmount = 0.1f; // Amount of water to fill per frame
    private float _maxWaterLevel = 100f; // Maximum water level

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Working");
        if (other.gameObject.CompareTag("Plane") && GameManager.getInstance().State != GameState.Lost)
        {
            if (WaterController.Instance.getWaterLevel() < _maxWaterLevel)
                WaterController.Instance.FillWater(_fillAmount);
        }
    }
}