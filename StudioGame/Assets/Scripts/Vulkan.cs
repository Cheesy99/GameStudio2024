using UnityEngine;

public class Vulkan : MonoBehaviour
{
    public GameObject prefabToThrow;
    public float throwForce = 20f; // Ändere die Wurfkraft hier
    public float throwInterval = 2f; // Zeitintervall zwischen den Würfen
    public float destroyDelay = 5f; // Zeit, nach der die Instanzen zerstört werden sollen
    public float minForwardSpeed = 1f; // Minimale Geschwindigkeit in Vorwärtsrichtung
    public float maxForwardSpeed = 3f; // Maximale Geschwindigkeit in Vorwärtsrichtung
    public float minRightSpeed = -2f; // Minimale Geschwindigkeit in Rechtsrichtung
    public float maxRightSpeed = 2f; // Maximale Geschwindigkeit in Rechtsrichtung
    public float minUpSpeed = 1f; // Minimale Geschwindigkeit in Aufwärtsrichtung
    public float maxUpSpeed = 3f; // Maximale Geschwindigkeit in Aufwärtsrichtung
    public int maxInstances = 5; // Maximale Anzahl gleichzeitig erstellter Instanzen

    private float throwTimer = 0f;

    void Update()
    {
        throwTimer += Time.deltaTime;

        if (throwTimer >= throwInterval)
        {
            for (int i = 0; i < maxInstances; i++)
            {
                ThrowPrefab();
            }
            throwTimer = 0f;
        }
    }

    void ThrowPrefab()
    {
        if (prefabToThrow == null)
        {
            Debug.LogError("Prefab is not assigned.");
            return;
        }

        GameObject thrownObject = Instantiate(prefabToThrow, transform.position, Quaternion.identity);

        // Zufällige Geschwindigkeiten generieren
        float forwardSpeed = Random.Range(minForwardSpeed, maxForwardSpeed);
        float rightSpeed = Random.Range(minRightSpeed, maxRightSpeed);
        float upSpeed = Random.Range(minUpSpeed, maxUpSpeed);

        // Festlegen der Wurfrichtung
        Vector3 throwDirection = transform.up * upSpeed + transform.forward * forwardSpeed + transform.right * rightSpeed; // Kombination aus Vorwärts-, Rechts- und Aufwärtsrichtung

        // Anwenden der Kraft
        Rigidbody rb = thrownObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(throwDirection.normalized * throwForce, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("Thrown object doesn't have a Rigidbody component.");
            Destroy(thrownObject);
            return;
        }

        // Objekt nach einer bestimmten Zeit zerstören
        Destroy(thrownObject, destroyDelay);
    }
}
