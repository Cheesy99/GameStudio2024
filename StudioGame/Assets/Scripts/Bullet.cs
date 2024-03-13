using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 5f;

   void Awake() {
    Destroy(gameObject,life);
   }
}
