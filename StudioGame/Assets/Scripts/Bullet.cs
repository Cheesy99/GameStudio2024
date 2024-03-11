using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3f;

   void Awake(){
    Destroy(gameObject,life);
   }
}
