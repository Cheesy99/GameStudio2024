using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    private ParticleSystem FireParicParticleSystem;
    // Start is called before the first frame update
    
    private void Awake()
    {
        FireParicParticleSystem = GetComponent<ParticleSystem>();
    }                                              
    private void OnCollisionEnter(Collision collision)
{
    Debug.Log("Collision detected");
    var main = FireParicParticleSystem.main;
    float currentSize = main.startSize.constant;
    currentSize -= 10f; // Decrease the start size by 10 each time a collision occurs
    if (currentSize < 0) currentSize = 0; // Ensure the start size doesn't go below 0
    main.startSize = currentSize;
}
}
