using UnityEngine;

public class SpawnObjectsOnKeyPress : MonoBehaviour
{
    public GameObject objectToSpawn; // Das Objekt, das du instanziieren möchtest
    public int numberOfInstances = 100; // Anzahl der zu erstellenden Instanzen
    public float spawnRadius = 0.5f; // Radius um den aktuellen Spielerstandort (entspricht der Hälfte des 1x1-Bereichs)
    private bool isKeyPressed = false; // Verfolge, ob die Taste gedrückt wurde

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            isKeyPressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.X)) // Wenn die Taste losgelassen wird
        {
            isKeyPressed = false;
        }

        if (isKeyPressed) // Wenn die Taste gedrückt wurde
        {
            // Berechne die Schrittweite für die X-, Y- und Z-Koordinaten
            float stepSize = 0.4f / Mathf.Sqrt(numberOfInstances);

            for (int i = 0; i < numberOfInstances; i++)
            {
                // Berechne die Position im 1x1x1-Würfel
                float x = transform.position.x - 0.5f + (i % 10) * stepSize;
                float y = transform.position.y - 0.5f + (i / 10) * stepSize;
                float z = transform.position.z - 0.5f + (i / 100) * stepSize;

                Vector3 spawnPosition = new Vector3(x, y, z);
                Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            }
        }
    }
}
