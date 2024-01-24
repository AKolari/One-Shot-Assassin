using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class AimLine : MonoBehaviour
{
    
    private LineRenderer lineRenderer;
    private bool drawing = true;
    public Bullet blank;
    


    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    
    void FixedUpdate()
    {
        if(drawing)
        {

            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount-1, transform.position);
            if(blank==null)
            {
                drawing = false;

            }
        }
    }
}
