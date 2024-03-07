using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3f;

   void Awake(){
    Destroy(gameObject,life);
   }

    void OnTriggerEnter(Collider collision)
    {
        // Überprüfe, ob das kollidierte Gameobjekt den Tag "Enemy" hat
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Zerstöre das kollidierte Gameobjekt (Enemy)
            Destroy(collision.gameObject);
             Destroy(gameObject);
        }
        
       
    }
}
