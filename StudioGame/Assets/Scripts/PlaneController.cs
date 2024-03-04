using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    
    [Header("Plane Stats")]
    [Tooltip("How much the throttle ramps up or down per frame.")] 
    public float throttleIncrement = 0.1f;
    [Tooltip("Maximum engine thrust when at 100%")]
    public float maxThrust = 200f;
    [Tooltip("How responsive the plane is when rolling, pitching, and yawing.")]
    public float responsiveness = 10f;

    private float throttle;
    private float roll;
    private float pitch;
    private float yaw;
    

    private float responseModifier {
        get
        {
            return (rb.mass / 10f) * responsiveness;
        }
    }
    Rigidbody rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    private void HandleInput()
    {
        // Set rotational values from our axis input
        roll = Input.GetAxis("Roll");
        pitch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");

        // Handle throttle value being sure to clamp it between 0 and 100
        if(Input.GetKey(KeyCode.Space)) throttle += throttleIncrement;
        else if(Input.GetKey(KeyCode.LeftControl)) throttle -= throttleIncrement;
        throttle = Mathf.Clamp(throttle, 0f, 100f);
    }
    // Start is called before the first frame update

    // Update is called once per frame
    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        //Apply forces to the plane
        rb.AddForce(transform.forward * throttle * maxThrust);
        rb.AddTorque(transform.up * yaw * responseModifier);
        rb.AddTorque(transform.right * roll * responseModifier);
        rb.AddTorque(transform.forward * pitch * responseModifier);
    }
}