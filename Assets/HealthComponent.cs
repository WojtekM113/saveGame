using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float health = 100;

    public float points;
    // Start is called before the first frame update

    private void OnEnable()
    {
        PointScript.OnPointCollected += UpdatePoints;
    }

    private void OnDisable()
    {
        PointScript.OnPointCollected -= UpdatePoints;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdatePoints()
    {
        points += 1;
    }

    
}
