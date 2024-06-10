using System;
using System.Collections;
using System.Collections.Generic;
using Platformer.SaveSystem;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    public SaveData saveData;
    public delegate void CollectedAction(string id);

    public string id;
    
 
    public static event CollectedAction OnPointCollected;
    void Start()
    {
        id = Guid.NewGuid().ToString();
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(OnPointCollected != null)
        {
            OnPointCollected(id); 
        }
        
        Destroy(this.gameObject);
    }
    
}
