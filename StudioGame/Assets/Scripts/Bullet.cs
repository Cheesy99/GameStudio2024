using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 5f;
    public ParticleSystem impactParticles;

   void Awake() {
    Destroy(gameObject,life);
   }


 
    
    

    void OnCollisionEnter(Collision collision)
    {
        // Überprüfe, ob die Kollision mit einem GameObject mit dem Tag "Wand" stattfindet
        if (collision.gameObject.CompareTag("Landschaft")|| collision.gameObject.CompareTag("Enemy"))
        {
            // Aktiviere das Partikelsystem an der Position der Kollision
            if (impactParticles != null)
            {
                // Erstelle das Partikelsystem an der Position des Bullet
                ParticleSystem particles = Instantiate(impactParticles, transform.position, Quaternion.identity);

                // Starte das Partikelsystem
                particles.Play();

                // Zerstöre das Partikelsystem nach der Partikelspielzeit
                Destroy(particles.gameObject, particles.main.duration);
            }

            // Zerstöre den Bullet
            Destroy(gameObject);
        }
    }
}

