using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropState : MonoBehaviour
{
    private DirtBlock dirtBlock;
    
    public GameObject growDoneCube;

    private bool waterPlz = false;      //물이 필요한지
    private bool growDone = false;      //다 자랐는지
    private bool canHarvest = false;    //재배 가능

    private Vector3 cropPos;
    void Start(){
        cropPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(growDone){       
            GameObject.Instantiate(growDoneCube, cropPos + new Vector3 (0, 1.5f, 0), Quaternion.identity).transform.parent = this.transform;
            growDone = false;
            canHarvest = true;
        }

        if(canHarvest && Input.GetKeyDown(KeyCode.Q)){
            Destroy(gameObject); //된다.
        }
    }

    public void GrowDone(){
        growDone = true;
    }
}
