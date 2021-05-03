using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float speed = 30f;
    public Transform rotationCenter;

    void Update()
    {
        transform.RotateAround(rotationCenter.position, Vector3.up, speed * Time.deltaTime);
    }
}
