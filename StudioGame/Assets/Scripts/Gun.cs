using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public Slider waterLevelSlider;
    
    public float bulletSpeed = 0.3f;
    public float waterLevel = 100f;
    

    // Gun Sound effect

    public AudioClip soundClip; // Der Sound-Clip, den du abspielen möchtest
    private AudioSource audioSource; // Der AudioSource-Komponente


      void Start()
    {
        // Füge eine AudioSource-Komponente zum GameObject hinzu
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = soundClip;
        audioSource.Stop(); // Stelle sicher, dass der Sound zu Beginn gestoppt ist
    }
    
    void Update()
    {

       
        if (Input.GetKeyDown(KeyCode.O) && waterLevel > 0)
        {

           
            var bullet = Instantiate(bulletPrefab,bulletSpawnPoint.position,bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity=8*(bulletSpawnPoint.forward*bulletSpeed);
           // aktiv sound
            PlaySound();

            waterLevel -= 1;// Decrease the water level
            waterLevelSlider.value = waterLevel;
        }

          
       
    }

void PlaySound()
    {
        // Überprüfe, ob die AudioSource-Komponente und der Sound-Clip vorhanden sind
        if (audioSource != null && soundClip != null)
        {
            // Spiele den Sound ab
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource oder Sound-Clip fehlt.");
        }
    }
   
}
