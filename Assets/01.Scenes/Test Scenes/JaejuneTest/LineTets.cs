using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTets : MonoBehaviour
{
    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetWidth(1.0f, 1.0f);
        lineRenderer.SetVertexCount(5); 

        lineRenderer.SetPosition(0, transform.position);
        //lineRenderer.SetPosition(1, transform.position + new Vector3(0, 10, 0));
        lineRenderer.SetPosition(1, transform.position + new Vector3(0, 10, 0));
        lineRenderer.SetPosition(2, transform.position + new Vector3(10, 10, 0));
        lineRenderer.SetPosition(3, transform.position + new Vector3(10, 0, 0));
        lineRenderer.SetPosition(4, transform.position);


        // lineRenderer.SetPosition(0, transform.position + new Vector3(20, 20, 20));
        // lineRenderer.SetPosition(1, transform.position + new Vector3(20, 30, 20));
        // lineRenderer.SetPosition(1, transform.position + new Vector3(30, 30, 20));
        // lineRenderer.SetPosition(1, transform.position + new Vector3(30, 20, 20));
        // lineRenderer.SetPosition(1, transform.position + new Vector3(20, 20, 20));


    }

}
