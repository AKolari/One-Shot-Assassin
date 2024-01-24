using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    private Vector3 spawnPosition;
    private bool takenObject=false;
    GameObject obj;
    void Start()
    {
        obj = Instantiate(objectToSpawn);
        obj.transform.position = gameObject.transform.position;
        obj.GetComponent<DraggableObject>().isSpawner = true;
        spawnPosition = obj.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        if (obj.transform.position != spawnPosition)
        {
            obj = Instantiate(objectToSpawn);
            obj.transform.position = gameObject.transform.position;
            spawnPosition = obj.transform.position;
            obj.GetComponent<DraggableObject>().isSpawner = true;
            
        }
        
    }

    
   
    
}
