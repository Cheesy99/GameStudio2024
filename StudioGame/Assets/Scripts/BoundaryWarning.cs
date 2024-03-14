using UnityEngine;

public class BoundaryWarning : MonoBehaviour
{
    public GameObject warningPanel; // Assign this in the inspector

    private void OnTriggerEnter(Collider other)
    {
        
        warningPanel.SetActive(true); // Show the warning plane
    }

    private void OnTriggerExit(Collider other)
    {
        warningPanel.SetActive(false); // Hide the warning plane
    }
}