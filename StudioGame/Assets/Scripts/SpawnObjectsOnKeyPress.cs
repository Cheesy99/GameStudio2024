using UnityEngine;
using UnityEngine.UIElements;

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
                float x = - 0.5f + (i % 10) * stepSize;
                float y = - 0.5f + (i / 10) * stepSize;
                float z = - 0.5f + (i / 100) * stepSize;

                Vector3 spawnPosition = transform.position + transform.right*x +transform.up* y + transform.forward*z;

                // Instantiate the object
                GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.Euler(Random.Range(0f,360f),Random.Range(0f,360f),Random.Range(0f,360f)));

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
