using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArIndicator;

public class Testing : MonoBehaviour
{
    private Grid grid;
    private Vector3 testVecPosition;
    private Vector3 worldPosition;
    private Vector3 testTouchPosition;

    private void Awake()
    {
        ARTapToPlaceObject aRTapToPlace = GameObject.FindGameObjectWithTag("ARinteraction").GetComponent<ARTapToPlaceObject>();
        aRTapToPlace.planeOnObjectDelegate += GirdValueInstantiate;
    }

    public void GirdValueInstantiate(Transform parentTransform)
    {
        // Vector3 originPos = parentTransform.position;
        // originPos += new Vector3(-10, 1, -10);
        //plane의 scale은 2,2,2이고 원점은 0, 0, 0에서 시작한다 가정했을 때 x와 z가 -10만큼 뺴진 곳에서 시작해야 함.
        Vector3 originPos = parentTransform.position + new Vector3(-10f, 0.5f, -10f); 
        grid = new Grid(4, 2, 2f, originPos);
        // new Grid(2, 5, 5f, new Vector3(0, 0, -20));
        // new Grid(10, 10, 20f, new Vector3(-100, 0, 20));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //3D프로젝트 마우스의 포지션을 가져오기.
            testTouchPosition = TouchAR.GetWolrdMousePosition3D();
            grid.SetValue(testTouchPosition, 56);
        }

        if (Input.GetMouseButtonDown(1))
        {
            testTouchPosition = TouchAR.GetWolrdMousePosition3D();
            Debug.Log(grid.GetValue(testTouchPosition));
        }
    }
}


