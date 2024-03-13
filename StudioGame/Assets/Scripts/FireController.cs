using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

  public class FireController : MonoBehaviour
{
    public static FireController Instance { get; private set; }

    public Slider fireBar;
    private List<FireScript> fireScripts;
    private float maxFireSize;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);

        fireScripts = new List<FireScript>();
    }

    public void RegisterFire(FireScript fireScript)
    {
        if (!fireScripts.Contains(fireScript))
        {
            fireScripts.Add(fireScript);
            var main = fireScript.FireParicParticleSystem.main;
            maxFireSize += main.startSize.constant;
            fireBar.maxValue = maxFireSize;
            fireBar.value = 0;
        }
    }

    private void Update()
    {
        float totalFireSize = 0;
        foreach (var FireScript in fireScripts)
        {
            var main = FireScript.FireParicParticleSystem.main;
            totalFireSize += main.startSize.constant;
        }

        fireBar.value = totalFireSize;


        if (fireBar.value == 0)
            GameManager.getInstance().State = GameState.Won;

    }

}
