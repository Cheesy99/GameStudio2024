using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Script : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
            gameObject.SetActive(false);
    }
}