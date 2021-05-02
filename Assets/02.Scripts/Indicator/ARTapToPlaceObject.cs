using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
// using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARSubsystems;
using PlaneOnObject;

//버전이 바뀌면서 ARSessionOring의 RayCast함수가 ARRayCastManager클래스로 따로 빠졌다.

namespace ArIndicator
{
    public class ARTapToPlaceObject : MonoBehaviour
    {
        // ARSessionOrigin은 현실세상과 상호작용할 떄 중요한 역할을 한다.(구버전에서 사용)
        
        // 카메라가 가리키는 위치를 확인 및 공간에서 해당 위치를 나타 내기 위해 가상 물체를 배치할 수 있는 위치가 있는지 확인위함.
        // Pose는 3D포인트에 대해 position과 rotation으로 나타낸다.
        private Pose placementPose;
        private ARRaycastManager arRaycastManager;
        private bool placementPoseIsValid = false;
        
        public Transform farmPlaneTransform; //생성된 뒤에 값 살아있음.
        public GameObject placementIndicator; 
        public GameObject objectToPlacePrefab; // Plane Prefab
        public GameObject farmPlane; // 설치된 plane이 저장되는 변수
        public bool isPlane = false;

        void Start()
        {
            // arOrigin = FindObjectOfType<ARSessionOrigin>();
            arRaycastManager = FindObjectOfType<ARRaycastManager>();
        }

        void Update()
        {
            UpdatePlacementPose(); //Pose가 실시간 Update된다.
            UpdatePlacementIndicator(); //Pose에 따른 visual적인 변화를 실시간 Update

            //IsPlane : 땅바닥이 설치되어 있다는 소리. 한 개만 설치가능하다.
            if (!farmPlane)
            {
                if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    PlaceObject();
                    Farmer.FarmerInstantiate(farmPlaneTransform, GameObject.Find("UI").transform.FindChild("DebugText").gameObject);
                    isPlane = true;
                }
            }
            else 
            {
                if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    // GameObject.Find("UI").transform.FindChild("DebugText").gameObject.SetActive(true);
                }
            }
        }

        private void PlaceObject()
        {
            farmPlane = Instantiate(objectToPlacePrefab, placementPose.position, placementPose.rotation);
            farmPlaneTransform = farmPlane.GetComponent<Transform>();
        }

        private void UpdatePlacementPose()
        {
            //(0,0)은 카메라의 왼쪽하단, (1,1)은 오른쪽 상단 => (0.5, 0.5)는 중간.
            //카메라의 뷰포트 공간의 좌표를 스크린 화면 좌표로 변환하여, 화면중간으로 인디케이터를 띄우게 함.
            var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
            var hits = new List<ARRaycastHit>();

            //screenCenter : 광선을 쏠 지점으로 사용 됨.
            arRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

            placementPoseIsValid = hits.Count > 0;
            if (placementPoseIsValid)
            {
                placementPose = hits[0].pose;

                //Indicator의 rotation이 카메라가 보는 방향따라 변하지 않는 점을 개선하는 코드
                var cameraForward = Camera.current.transform.forward;
                var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z);
                placementPose.rotation = Quaternion.LookRotation(cameraBearing);
            }
        }

        private void UpdatePlacementIndicator()
        {
            if (placementPoseIsValid)
            {
                placementIndicator.SetActive(true);
                placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
            }
            else 
            {
                placementIndicator.SetActive(false);
            }
        }
    }
}
