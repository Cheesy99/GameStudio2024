using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem particlePrefab; // Prefab des Partikelsystems
    private GameObject particleHolder; // Leeres GameObject zur Aufnahme des Partikelsystems
    private ParticleSystem currentParticleSystem; // Aktuelle Instanz des Partikelsystems

    void Start()
    {
        // Erstelle ein leeres GameObject zur Aufnahme des Partikelsystems
        particleHolder = new GameObject("ParticleHolder");

        // Erstelle eine Instanz des Partikelsystems und ordne sie dem leeren GameObject zu
        currentParticleSystem = Instantiate(particlePrefab, particleHolder.transform.position, particleHolder.transform.rotation, particleHolder.transform);
        currentParticleSystem.Stop();
    }

    void Update()
    {
        // Hier kannst du prüfen, ob der Button gedrückt wurde.
        if (Input.GetKey(KeyCode.O)) // Du kannst den Tastennamen anpassen.
        {
            // Wenn eine aktuelle Instanz vorhanden ist, deaktiviere sie
            if (currentParticleSystem != null)
            {
                currentParticleSystem.Stop();
            }

            // Erstelle eine neue Instanz des Partikelsystems und weise sie dem leeren GameObject zu
            currentParticleSystem = Instantiate(particlePrefab, particleHolder.transform.position, particleHolder.transform.rotation, particleHolder.transform);
            // Starte das Partikelsystem
            currentParticleSystem.Play();
        }

        // Aktualisiere die Position des leeren GameObjects basierend auf der Position des übergeordneten Objekts
        particleHolder.transform.position = transform.position;
    }
}
