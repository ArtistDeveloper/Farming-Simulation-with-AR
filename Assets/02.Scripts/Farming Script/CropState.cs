using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CropState : MonoBehaviour
{
    //이거도 Crop에 들어가 있는 친구임.
    private DirtBlock dirtBlock;
    
    public GameObject growDoneCube;

    private bool waterPlz = false;      //물이 필요한지
    private bool growDone = false;      //다 자랐는지
    private bool canHarvest = false;    //재배 가능
    public string cropKind;             //잘 받아옴 -> 프리팹에 다 적어야함.
    public int cropCount;

    private Vector3 cropPos;
    private CropCountSave cropCountSave;

    void Start(){
        cropPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        cropCountSave = GameObject.Find("SaveManager").GetComponent<CropCountSave>();
    }

    void Update()
    {
        if(growDone){       
            GameObject.Instantiate(growDoneCube, cropPos + new Vector3 (0, 1.5f, 0f), Quaternion.identity).transform.parent = this.transform;
            growDone = false;
            canHarvest = true;
        }

        if(canHarvest && Input.GetKeyDown(KeyCode.Q)){      
            if(PlayerPrefs.HasKey(cropKind + "_Count")){
            PlayerPrefs.SetInt(cropKind + "_Count", PlayerPrefs.GetInt(cropKind + "_Count") + 1);       //Q(채집)을 할 때 마다 저장을 하는 것임.
            cropCountSave.LoadCropCountData();
            Destroy(gameObject);            //된다.
            }else{
                PlayerPrefs.SetInt(cropKind + "_Count", 1);
                Debug.Log(PlayerPrefs.GetInt(cropKind+"_Count"));
                Destroy(gameObject);
            }           
        }
    }

    public void GrowDone(){
        growDone = true;
    }
}
