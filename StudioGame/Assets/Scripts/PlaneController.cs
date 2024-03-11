using System;
using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{
    
    [Header("Plane Stats")]
    [Tooltip("How much the throttle ramps up or down per frame.")] 
    public float throttleIncrement = 1f;
    [Tooltip("Maximum engine thrust when at 100%")]
    public float maxThrust = 300f;
    [Tooltip("How responsive the plane is when pitching.")]
    private float pitchResponsiveness = 10f;
    [Tooltip("How responsive the plane is when rolling, and yawing.")]
    public float responsiveness = 10f;
    [Tooltip("How much lift the plane generates as it gains speed.")]
    public float lift = 135f;
    
    [Header("Shooting")]
    [Tooltip("The cube prefab to shoot.")]
    public GameObject cubePrefab;

    [Tooltip("The force with which the cube is shot.")]
    public float shootingForce = 50f;
    
    // Compase
    [SerializeField] private Image compassImage;

    private float throttle;  // Percentage of throttle
    private float roll;      // Tilting left ti right.
    private float pitch;     // Tilting up or down.
    private float yaw;      // Turning left or right.
    

    private float responseModifier { // Value used to tweak the responsiveness of the plane
        get
        {
            return (rb.mass / 10f) * responsiveness;
        }
    }
    
    
    Rigidbody rb;
    AudioSource engineSound;
    [SerializeField] TextMeshProUGUI hud;
    [SerializeField] Transform propeller;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        engineSound = GetComponent<AudioSource>();
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
        
        // Handle Shooting
        if (Input.GetKeyDown(KeyCode.F)) Fire();
    }
    
    private void Update()
    {
        
        UpdateHUD();
        UpdateCompass();
        propeller.Rotate(Vector3.right * throttle / 2f);
        engineSound.volume = throttle * 0.01f;
    }

    private void FixedUpdate()
    {
        HandleInput();
        //Apply forward force to the plane
        rb.AddForce(-transform.right * throttle * maxThrust);
        
        // Apply rotational forces to the plane
        rb.AddTorque(transform.up * yaw * responseModifier);
        rb.AddTorque(transform.right * roll * responseModifier);
        rb.AddTorque(-transform.forward * pitch * pitchResponsiveness);
        
        // Apply lift to the plane
        rb.AddForce(Vector3.up * rb.velocity.magnitude * lift);
    }

    private void UpdateCompass()
    {
        float playerAngle = transform.eulerAngles.y;
        compassImage.transform.rotation = Quaternion.Euler(0, 0, playerAngle);
    }

    private void UpdateHUD()
    {
        hud.text = "Throttle " + throttle.ToString("F0") + "%\n";
        hud.text += "Airspeed: " + (rb.velocity.magnitude * 3.6f).ToString("F0") + "km/h\n";
        hud.text += "Altitude: " + transform.position.y.ToString("F0") + "m";
    }

    private void Fire()
    {
        GameObject cube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
        
        Rigidbody cubeRb = cube.GetComponent<Rigidbody>();
        cubeRb.AddForce(-transform.up * shootingForce);
    }
}