using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    public delegate void CollectedAction();

    public static event CollectedAction OnPointCollected;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(OnPointCollected != null)
        {
            OnPointCollected();
        }
        Destroy(this.gameObject);
    }

    void SetPoints()
    {
        
    }
}
