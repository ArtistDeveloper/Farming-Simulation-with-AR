using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlacedObjectTypeSO : ScriptableObject
{
    public string nameString;
    public GameObject prefab;
    public Transform visual;
    public int width;
    public int height;

    public enum Dir
    {
        Down,
        Left,
        Up,
        Right,
    }

    public static Dir GetNextDir(Dir dir)
    {
        switch (dir)
        {
            default:
            case Dir.Down: return Dir.Left;
            case Dir.Left: return Dir.Up;
            case Dir.Up: return Dir.Right;
            case Dir.Right: return Dir.Down;
        }
    }

    // 이 함수는 오프셋을 취하므로 예를 들어 클릭하는 위치와 같은
    // 기본 오프셋이 된 다음 전체 너비를 순환하면서 전체 높이를 순환합니다.
    // 그런 다음 목록에 추가하여 오프셋과 x, y를 더한 다음 vector2 int 목록을 반환합니다.
    public List<Vector2Int> GetGridPositionList(Vector2Int offset, Dir dir)
    {
        List<Vector2Int> gridPositionList = new List<Vector2Int>();
        switch (dir)
        {
            default:
            case Dir.Down:
            case Dir.Up:
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        gridPositionList.Add(offset + new Vector2Int(x, y));
                    }
                }
                break;
            case Dir.Left:
            case Dir.Right:
                for (int x = 0; x < height; x++)
                {
                    for (int y = 0; y < width; y++)
                    {
                        gridPositionList.Add(offset + new Vector2Int(x, y));
                    }
                }
                break;
        }
        return gridPositionList;
    }
}
