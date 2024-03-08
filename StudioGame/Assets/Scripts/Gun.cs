using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public Rigidbody Aircraft;
    public float bulletSpeed = 0.3f;
    
    void Update()
    {

       
        if (Input.GetKeyDown(KeyCode.O))
        {
           
            var bullet = Instantiate(bulletPrefab,bulletSpawnPoint.position,bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity=8*(bulletSpawnPoint.forward*bulletSpeed);
            
        }
    }

   
}
