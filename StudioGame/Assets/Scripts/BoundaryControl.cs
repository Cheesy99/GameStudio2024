using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class BoundaryControl : MonoBehaviour
{
    public Canvas warningCanvas; // Assign this in the inspector

    // Start is called before the first frame update
    void Start()
    {
        warningCanvas.enabled = false; // Hide the warning canvas at the start
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane")) // Assuming the plane has the tag "Plane"
        {
            GameManager.getInstance().State = GameState.Lost;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Plane")) // Assuming the plane has the tag "Plane"
        {
            warningCanvas.enabled = true; // Show the warning canvas
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Plane")) // Assuming the plane has the tag "Plane"
        {
            warningCanvas.enabled = false; // Hide the warning canvas
        }
    }
}