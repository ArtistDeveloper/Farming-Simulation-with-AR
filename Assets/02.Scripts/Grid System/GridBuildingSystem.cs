using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArIndicator;

// GridBuildSystem.cs : 
// Grid를 생성함. Grid를 생성할 때 GridObject 타입의 값도 생성자 파라미터에 넘어감.
public class GridBuildingSystem : MonoBehaviour
{
    private Vector3 touchPosition;

    private Grid<GridObject> grid;
    public int x, z;

    // Test code
    public GameObject housePrefab;

    private void Awake()
    {
        ARTapToPlaceObject aRTapToPlace = GameObject.FindGameObjectWithTag("ARinteraction").GetComponent<ARTapToPlaceObject>();
        aRTapToPlace.planeOnObjectDelegate += GirdValueInstantiate;
    }

    // struct와 비슷한 개념으로 사용함.
    // GridObject에는 생성된 Grid와 x, z값
    public class GridObject
    {
        // Grid가 생성되면 g, x, y 파라미터로 전달되서 옴.
        private Grid<GridObject> grid;
        private int x;
        private int z;

        // 생성자
        public GridObject(Grid<GridObject> grid, int x, int z) 
        {
            this.grid = grid;
            this.x = x;
            this.z = z;
        }

        public override string ToString()
        {
            return x + ", " + z;
        }
    }

    public void GirdValueInstantiate(Transform parentTransform)
    {
        //plane의 scale은 2,2,2이고 원점은 0, 0, 0에서 시작한다 가정했을 때 x와 z가 -10만큼 뺴진 곳에서 시작해야 함.
        Vector3 originPos = parentTransform.position + new Vector3(-10f, 0.1f, -10f);
        int gridWidth = 10;
        int gridHeight = 10;
        float cellSize = 2f;
        grid = new Grid<GridObject>(gridWidth, gridHeight, cellSize, originPos, parentTransform, (Grid<GridObject> g, int x, int y) => new GridObject(g, x, y));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //3D프로젝트 마우스의 포지션을 가져오기.
            touchPosition = TouchAR.GetWolrdMousePosition3D();
            grid.GetXZ(touchPosition, out x, out z);
            Instantiate(housePrefab, grid.GetWorldPosition(x, z), Quaternion.identity);
        }

        if (Input.GetMouseButtonDown(1))
        {
            touchPosition = TouchAR.GetWolrdMousePosition3D();
        }
    }

    private void BuildHouse()
    {

    }
}


