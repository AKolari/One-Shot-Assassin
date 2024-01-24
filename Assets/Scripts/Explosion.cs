using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float endTime;
    void Start()
    {
        endTime = Time.time + 2;  
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > endTime)
        {

            Destroy(gameObject);
        }
    }
}
