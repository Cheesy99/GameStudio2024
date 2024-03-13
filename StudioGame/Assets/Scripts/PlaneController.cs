using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
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

    public static bool hasCollided = false;
    
    [Header("Shooting")]
    [Tooltip("The cube prefab to shoot.")]
    public GameObject cubePrefab;

    [Tooltip("The explosion effect to instantiate when a collision occurs.")]
    public GameObject explosionPrefab;
    [Tooltip("The force with which the cube is shot.")]
    public float shootingForce = 50f;
    
    // Compase
    [SerializeField] private Image compassImage;

    private float throttle;  // Percentage of throttle
    private float roll;      // Tilting left ti right.
    private float pitch;     // Tilting up or down.
    private float yaw;      // Turning left or right.
    private Vector3 lastPosition;
    

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
        hasCollided = false;
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Level_2") // replace "Level2" with the actual name of your level 2 scene
        {
            throttle = 100f;
        }
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
        throttle = Mathf.Clamp(throttle, 0f, 10f);
        
        // Handle Shooting
        if (Input.GetKeyDown(KeyCode.F)) Fire();
    }
    
    private void Update()
    {
        HandleInput();
        UpdateHUD();
        UpdateCompass();
        propeller.Rotate(Vector3.right * (throttle + 10));
        engineSound.volume = throttle * 0.01f;

        lastPosition = transform.position; // Save the last position of the plane
    }

    private void FixedUpdate()
    {
       
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
        hud.text = "0";
        if (throttle == 0)
        {
            hud.text = "Throttle " + throttle.ToString("F0") + "%\n";
        }
        else
        {
            hud.text = "Throttle " + throttle.ToString("F0") + "0" + "%\n";
        }

        hud.text += "Airspeed: " + (rb.velocity.magnitude * 3.6f).ToString("F0") + "km/h\n";
        hud.text += "Altitude: " + transform.position.y.ToString("F0") + "m";
    }

    private void Fire() 
    {
        GameObject cube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
        
        Rigidbody cubeRb = cube.GetComponent<Rigidbody>();
        cubeRb.AddForce(-transform.up * shootingForce);
    }

    private void OnCollisionEnter(Collision other)
    {
       Vector3 collisionDirection = transform.position - lastPosition;
           collisionDirection.y = 0; // Ignore y axis
       
           if (collisionDirection.magnitude <= 0.01f) return; // Ignore minor collisions
       
           if (transform.position.y <= 5.0f) return;
           
        GameManager.getInstance().State = GameState.Lost;
        
        // Instantiate the explosion effect at the plane's position
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Disable the plane's renderer and collider to make it disappear
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        foreach (Transform child in transform)
        {
            // Instantiate the explosion effect at the child's position
            Instantiate(explosionPrefab, child.position, Quaternion.identity);

            // Disable the child's renderer and collider to make it disappear
            if (child.GetComponent<Renderer>() != null)
                child.GetComponent<Renderer>().enabled = false;
            
            if (child.GetComponent<Collider>() != null)
                child.GetComponent<Collider>().enabled = false;
            
        }

        hasCollided = true;
    }
}