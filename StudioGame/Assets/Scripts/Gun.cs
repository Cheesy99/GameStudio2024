using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public Rigidbody Aircraft;
    public Transform target; // Assign the target in the Unity Editor

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        if (target != null)
        {
            // Calculate the direction from the bullet spawn point to the target
            Vector3 directionToTarget = (target.position - bulletSpawnPoint.position).normalized;

            // Create a rotation based on the direction
            Quaternion rotation = Quaternion.LookRotation(directionToTarget);

            // Instantiate the bullet with the calculated rotation
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, rotation);

            // Get the rigidbody component of the bullet
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

            if (bulletRigidbody != null)
            {
                // Set the velocity of the bullet based on the calculated direction and bullet speed
                bulletRigidbody.velocity = Aircraft.velocity+(directionToTarget * bulletSpeed);
            }
            else
            {
                Debug.LogWarning("Bullet is missing a Rigidbody component.");
            }
        }
        else
        {
            Debug.LogWarning("No target assigned. Please assign a target in the Unity Editor.");
        }
    }
}
