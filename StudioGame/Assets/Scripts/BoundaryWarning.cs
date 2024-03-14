using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryWarning : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Plane")) // Assuming the plane is on the layer "Plane"
        {
            warningCanvas.enabled = true; // Show the warning canvas
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Plane")) // Assuming the plane is on the layer "Plane"
        {
            warningCanvas.enabled = false; // Hide the warning canvas
        }
    }
}