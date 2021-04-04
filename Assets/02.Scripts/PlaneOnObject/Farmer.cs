using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Farmer : MonoBehaviour
{
    public GameObject farmer;
    private GameObject farmPlane;
    public Text debugText;

    void Start()
    {
        debugText.text = "터치되고 있습니다.";
    }

    // Update is called once per frame
    void Update()
    {
        if (farmPlane != null)
        {
            if (Input.touchCount > 0)
            {
                GameObject.FindWithTag("DebugText").SetActive(true);
                farmPlane = GameObject.Find("Interaction").GetComponent<ARTapToPlaceObject>().farmPlane;
                Vector3 yUpperPos = farmPlane.transform.position;
                yUpperPos.y += yUpperPos.y + 1.5f;
                Instantiate(farmer, yUpperPos, farmPlane.transform.rotation);
            }
        }
    }
}
