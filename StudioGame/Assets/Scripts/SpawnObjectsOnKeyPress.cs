using UnityEngine;

public class SpawnObjectsOnKeyPress : MonoBehaviour
{
    public GameObject objectToSpawn;
    public int numberOfInstances = 100;
    public float spawnRadius = 0.5f;
    private bool isKeyPressed = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            isKeyPressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            isKeyPressed = false;
        }

        if (isKeyPressed)
        {
            float stepSize = 0.4f / Mathf.Sqrt(numberOfInstances);

            for (int i = 0; i < numberOfInstances; i++)
            {
                float x = transform.position.x - 0.5f + (i % 10) * stepSize;
                float y = transform.position.y - 0.5f + (i / 10) * stepSize;
                float z = transform.position.z - 0.5f + (i / 100) * stepSize;

                Vector3 spawnPosition = new Vector3(x, y, z);

                // Instantiate the object
                GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

                // Check if the objectToSpawn is null (Prefab might be missing)
                if (objectToSpawn == null)
                {
                    Debug.LogError("Prefab is missing or null.");
                    return;
                }

                // Zerstöre die Instanz nach 3 Sekunden
                Destroy(spawnedObject, 3f);
            }
        }
    }
}
