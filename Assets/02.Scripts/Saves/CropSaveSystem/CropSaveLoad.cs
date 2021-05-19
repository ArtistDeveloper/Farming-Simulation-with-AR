using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class CropSaveLoad : MonoBehaviour
{   
    public void SaveCrop(){
        CropSaveManager.Save(GameObject.FindObjectsOfType<CropGrowTime>());        //Crop이거도 넣어줘
        Debug.Log("CropSaveLoad에서 Save실행 끝");
    }

    public void LoadCrop(){
        AllCropsData save = CropSaveManager.Load();
        //태그 해줘야함! - 어려운거 아니니까 까먹지 말쟈~!
        GameObject[] crops = GameObject.FindGameObjectsWithTag("Crop");
        //Debug.Log("cropSaveDatas : "+save.cropSaveDatas.Length);        //20
        //Debug.Log("crops : "+ crops.Length);            //20 - 맞음.

        for(int i=0; i <= save.cropSaveDatas.Length -1; i++){      //int i=save.cropSaveDatas.Length-1; i>=0; i--
            CropGrowTime cropGrowTime = crops[i].GetComponent<CropGrowTime>();
            Debug.Log("Load함수에 있는 remainGrowTime : " + save.cropSaveDatas[i].remainGrowTimeSave);
            cropGrowTime.remainGrowTime = save.cropSaveDatas[i].remainGrowTimeSave;
            cropGrowTime.witherOrGather = save.cropSaveDatas[i].witherOrGather;
        }
        Debug.Log("CropSaveLoad의 Load 끝 즉 remainGrowTime이 Crop에 전해짐.");
    }

}
