using UnityEngine;


public class KillControl : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane")) 
        {
            GameManager.getInstance().State = GameState.Lost;
        }
    }
    
}