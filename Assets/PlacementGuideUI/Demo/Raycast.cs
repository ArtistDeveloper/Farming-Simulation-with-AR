using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    /// <summary>
    /// Holds Position and Normal vectors which are used as a return value of custom raycast
    /// </summary>
    private class PosNormal
    {
        public Vector3 Position;
        public Vector3 Normal;


        public PosNormal(Vector3 position, Vector3 normal)
        {
            Position = position;
            Normal = normal;
        }
    }

    [SerializeField] GameObject PlacementGuideObject = null;
    private Camera MainCamera;
    private PlacementGuide placementGuide;
    public float MaxRaycastDistance = 50f;

    private void Awake()
    {
        MainCamera = Camera.main;
        placementGuide = PlacementGuideObject.GetComponent<PlacementGuide>();
        placementGuide.Deactivate();
    }

    void FixedUpdate()
    {
        //if mouse button (left hand side) pressed instantiate a raycast
        if (Input.GetMouseButton(0))
        {
            //create a ray cast and set it to the mouses cursor position in game
            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, MaxRaycastDistance))
            {
                //draw invisible ray cast/vector
                Debug.DrawLine(ray.origin, hit.point);
                //log hit area to the console
                placementGuide.ActivateAt(hit.point, hit.normal);
                

            }
            else
            {
                placementGuide.Deactivate();
            }
        }
        if (Input.GetMouseButton(1))
        {
            placementGuide.Deactivate();
        }
    }
}
