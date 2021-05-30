using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using ArIndicator;

// GridBuildSystem.cs : 
// Grid를 생성함. Grid를 생성할 때 GridObject 타입의 값도 생성자 파라미터에 넘어감.
public class GridBuildingSystem : MonoBehaviour
{
    private Grid<GridObject> grid;
    public int x, z;
    private Vector3 touchPosition;
    private int touchX, touchZ;
    private GameObject saveManager;
    public Vector3 originPos;

    // public static TouchXZpostion touchXZpostion;

    // 건물 설치 방향 정하기
    private static PlacedObjectTypeSO.Dir dir = PlacedObjectTypeSO.Dir.Down; // Down이 디폴트

    // mode selecter
    private static bool removeMode = false;
    private static bool installMode = false;

    // prefab
    [SerializeField] private GameObject housePrefab;
    [SerializeField] private static PlacedObjectTypeSO placedObjectTypeSO;
    [SerializeField] private List<PlacedObjectTypeSO> placedObjectTypeSOList;

    private void Awake()
    {
        ARTapToPlaceObject aRTapToPlace = GameObject.FindGameObjectWithTag("ARinteraction").GetComponent<ARTapToPlaceObject>();
        aRTapToPlace.planeOnObjectDelegate += GirdValueInstantiate;

        placedObjectTypeSO = placedObjectTypeSOList[0];
    }

    // GridObject에는 생성된 Grid에서 셀에 해당하는 x, z값을 들고있음. struct와 비슷한 개념으로 사용함.
    // Grid셀에서 각 셀은 GridObject타입으로 만들어짐.
    public class GridObject
    {
        // Grid가 생성되면 g, x, y 파라미터로 전달되서 옴.
        private Grid<GridObject> grid;
        private int x;
        private int z;
        // 객체 중복생성 방지 코드 이 그리드 오브젝트 위에 배치되는 변환의 이름을 지정
        // private Transform transform;
        private PlacedObjectOfBuilding placedObject;

        // 생성자
        public GridObject(Grid<GridObject> grid, int x, int z)
        {
            this.grid = grid;
            this.x = x;
            this.z = z;
        }

        // Grid의 x, y값을 받아와서 x, y에 해당하는 GridObject셀에 transform의 값을 넣는다.
        public void SetPlcaedObject(PlacedObjectOfBuilding placedObject)
        {
            this.placedObject = placedObject;
            grid.TriggerGridObjectChanged(x, z); // 현재 셀에 해당되는 x, z값이 매개변수로 넘어간다.
        }

        public PlacedObjectOfBuilding GetPlacedObject()
        {
            return placedObject;
        }

        public void ClearPlacedObject()
        {
            placedObject = null;
        }

        // transform이 null이면 true반환. !굳이 transform말고 bool값으로 해도 되지 않았을까? 일단 다음에 코드를 수정해보자.
        public bool CanBuild()
        {
            return placedObject == null;
        }


        public override string ToString()
        {
            return x + ", " + z + "\n" + placedObject;
        }
    }

    public void GirdValueInstantiate(Vector3 planeTransformPosition, Quaternion rotation)
    {
        //plane의 scale은 2,2,2이고 원점은 0, 0, 0에서 시작한다 가정했을 때 x와 z가 -10만큼 뺴진 곳에서 시작해야 함.
        originPos = planeTransformPosition + new Vector3(-10f, 0.1f, -10f);
        int gridWidth = 20;
        int gridHeight = 20;
        float cellSize = 1.0f;
        grid = new Grid<GridObject>(gridWidth, gridHeight, cellSize, originPos, rotation, (Grid<GridObject> g, int x, int y) => new GridObject(g, x, y));
        saveManager = GameObject.FindWithTag("SaveManagerParent").transform.GetChild(0).gameObject;
        saveManager.SetActive(true);
    }

    private void FixedUpdate()
    {
        // && (EventSystem.current.IsPointerOverGameObject()==false) 
        // && !IsPointerOverUIObject(TouchAR.GetWolrdTouchPosition3D())
        // Input.GetMouseButtonDown(0)
        if (installMode && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // !EventSystem.current.IsPointerOverGameObject() 컴퓨터에서는 됨.
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                touchPosition = TouchAR.GetWolrdTouchPosition3D(); //3D프로젝트 마우스의 포지션을 가져오기.

                grid.GetXZ(touchPosition, out x, out z);

                List<Vector2Int> gridPositionList = placedObjectTypeSO.GetGridPositionList(new Vector2Int(x, z), dir);

                bool canBuild = true;
                foreach (Vector2Int gridPosition in gridPositionList)
                {
                    // GridObject셀을 터치했을 때 그 오프셋부터 다른 범위부분에 Build할 수 없는 부분이 있으면 터치했던 GridObject셀은 false값으로 바뀌게 되어 instantiate하지 못하게 된다.
                    if (!grid.GetGridObject(gridPosition.x, gridPosition.y).CanBuild())
                    {
                        canBuild = false;
                        break;
                    }
                }

                GridObject gridobject = grid.GetGridObject(x, z);
                if (canBuild)
                {
                    Vector2Int rotationOffset = placedObjectTypeSO.GetRotationOffset(dir);
                    Vector3 placedObjectWorldPosition = grid.GetWorldPosition(x, z) +
                        new Vector3(rotationOffset.x, 0, rotationOffset.y) * grid.CellSize;

                    PlacedObjectOfBuilding placedObject = PlacedObjectOfBuilding.Create(placedObjectWorldPosition, new Vector2Int(x, z), dir, placedObjectTypeSO);
                    

                    // 건물 영역만큼 건물이 설치된 부위로 set하기.      
                    // farmPlane에서 터치한 x, z좌표에 해당하는 GridOvject셀을 가져와서 gridPosition만큼 설치된 부분으로 set한다.
                    foreach (Vector2Int gridPosition in gridPositionList)
                    {
                        grid.GetGridObject(gridPosition.x, gridPosition.y).SetPlcaedObject(placedObject);
                    }
                    gridobject.SetPlcaedObject(placedObject);


                }
            }
        }

        if (removeMode && Input.GetMouseButtonDown(0))
        {
            GridObject gridObject = grid.GetGridObject(TouchAR.GetWolrdTouchPosition3D());
            PlacedObjectOfBuilding placedObject = gridObject.GetPlacedObject();
            if (placedObject != null)
            {
                placedObject.DestroySelf();
                List<Vector2Int> gridPositionList = placedObject.GetGridPositionList();
                foreach (Vector2Int gridPosition in gridPositionList)
                {
                    grid.GetGridObject(gridPosition.x, gridPosition.y).ClearPlacedObject();
                }
            }
        }
    }

    public void RotateBuilding()
    {
        dir = PlacedObjectTypeSO.GetNextDir(dir);
        GameObject.Find("UI").transform.FindChild("DebugText").gameObject.SetActive(true);
    }

    public void SelectBuilding(int number)
    {
        switch (number)
        {
            case 1:
                placedObjectTypeSO = placedObjectTypeSOList[number];
                break;
        }
    }

    public void RemoveModeSelecter()
    {
        if (removeMode == false) removeMode = true;
        else if (removeMode == true) removeMode = false;
    }

    public void InstallModeSelecter(int installToggle)
    {
        if (installToggle == 1) installMode = true;
        else if (installToggle == 0) installMode = false;
    }

    public bool IsPointerOverUIObject(Vector2 touchPos)
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);

        eventDataCurrentPosition.position = touchPos;
        List<RaycastResult> results = new List<RaycastResult>();

        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        return results.Count > 0;
    }
}