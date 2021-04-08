using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ArIndicator;

namespace PlaneOnObject
{
    public class Farmer : MonoBehaviour
    {
        public GameObject farmer;
        private Transform farmPlanePosition;

        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            farmPlanePosition = GameObject.Find("Interaction").GetComponent<ARTapToPlaceObject>().farmPlanePosition;
            Vector3 yUpperPos = farmPlanePosition.position;
            yUpperPos.y += yUpperPos.y + 0.5f;
            Instantiate(farmer, yUpperPos, farmPlanePosition.rotation);

            // if (farmPlane != null)
            // {
            //     Vector3 yUpperPos = farmPlane.transform.position;
            //     yUpperPos.y += yUpperPos.y + 0.5f;
            //     Instantiate(farmer, yUpperPos, farmPlane.transform.rotation);
            // }
            
        }

        //public void FarmerInstantiate()
        //{
        //    farmPlane = GameObject.Find("Interaction").GetComponent<ARTapToPlaceObject>().farmPlane;
        //    Vector3 yUpperPos = farmPlane.transform.position;
        //    yUpperPos.y += yUpperPos.y + 0.5f;
        //    Instantiate(farmer, yUpperPos, farmPlane.transform.rotation); 

        //    //텍스트띄우기
        //    GameObject.Find("DebugText").SetActive(true);
        //}
    }
}