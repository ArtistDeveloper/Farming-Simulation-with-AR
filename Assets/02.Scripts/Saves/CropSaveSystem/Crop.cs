using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Crop : MonoBehaviour
{   
    public void SaveCrop(){
         CropSaveManager.Save(GameObject.FindObjectsOfType<CropTime>());        //Crop이거도 넣어줘
         Debug.Log("Crop저장 완료");
    }

    public void LoadCrop(){
        AllCropsData save = CropSaveManager.Load();
        GameObject[] crops = GameObject.FindGameObjectsWithTag("Crop");
        //태그 해줘야함! - 어려운거 아니니까 까먹지 말쟈~!
        Debug.Log("cropSaveDatas : "+save.cropSaveDatas.Length);        //20
        Debug.Log("crops : "+ crops.Length);            //21 - 맞음.

        for(int i=save.cropSaveDatas.Length-1; i>=0; i--){
            CropTime cropTime = crops[i].GetComponent<CropTime>();
            Debug.Log("Load함수에 있는 remainGrowTime : " + save.cropSaveDatas[i].remainGrowTimeSave);
            cropTime.remainGrowTime = save.cropSaveDatas[i].remainGrowTimeSave;
            
        }
        Debug.Log("Crop클래스의 Load 끝");
        
    }
    
    public void CropSaveDataDelete(){
        if("Crop Save.bin" != null){
            File.Delete("Crop Save.bin");
            Debug.Log("Crop Save 삭제 완료");
        }       //이 방식은 Load가 끝난 후 데이터를 삭제하는 방식입니다.
    }

}
