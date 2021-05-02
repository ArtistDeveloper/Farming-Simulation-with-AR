 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

// 참고 자료입니다.
//이게 SaveSystem

public static class CropSaveManager
{
    public static void Save(CropTime[] crops){ 
        if("Crop Save.bin" != null){
            File.Delete("Crop Save.bin");
            Debug.Log("Crop Save 삭제 완료");
        }

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.dataPath, "Crop Save.bin ");
        
        FileStream stream =File.Create(path);

        CropSaveData[] cropSaveDatas = new CropSaveData[crops.Length];
        for(int i = 0; i<crops.Length; ++i){
            cropSaveDatas[i] = new CropSaveData(crops[i]);
        }

        AllCropsData data = new AllCropsData(cropSaveDatas);

        formatter.Serialize(stream, data);
        stream.Close();
    }


    public static AllCropsData Load(){
        try{
         BinaryFormatter formatter = new BinaryFormatter();
         string path = Path.Combine(Application.dataPath, "Crop Save.bin");
         FileStream stream = File.OpenRead(path);
         AllCropsData data = (AllCropsData)formatter.Deserialize(stream);
         stream.Close();
         return data;

         }
         catch(Exception e){
             Debug.Log(e.Message);
             return default;
         }
     }

}
