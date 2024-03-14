using System.Collections;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public GameObject panel; // Assign your panel in the inspector
    private bool isInsideTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        // Start the coroutine when an object enters the trigger
        StartCoroutine(ShowPanel());
    }

    IEnumerator ShowPanel()
    {
        // Show the panel
        panel.SetActive(true);

        // Wait for 4 seconds
        yield return new WaitForSeconds(4f);

        // Hide the panel
        panel.SetActive(false);
    }
}