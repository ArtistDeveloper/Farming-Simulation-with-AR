using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class FarmSaveLoad : MonoBehaviour
{
    public GameObject farmPrefab;
    private AllFarmsData save;
    GameObject[] farms;

    public void OnApplicationFocus(bool value){
        if(value){      //들어왔을 때 실행.
            LoadFarm();     //원래 친구 삭제 후 복사해서 놓음.
            Debug.Log("FarmSaveLoad함수 내의 Load");
        }else
        {
            SaveFarm();
            Debug.Log("FarmSaveLoad함수 내의 Save");
        }
    }

    public void OnApplicationQuit()
    {
        SaveFarm();
        //Debug.Log("Farm 저장 완료");
    }


    public void SaveFarm(){
        FarmSaveDataDelete();
        FarmSaveManager.Save(GameObject.FindObjectsOfType<Farm>());         //이건 잘 될거임 - 왜냐면 Tpye을 가져오기 때문에 Farm이라는 스크립트 다 있음.
    }

    public void LoadFarm(){
        save = FarmSaveManager.Load();
        farms = GameObject.FindGameObjectsWithTag("Farm");  // Tag도 동일하게 되어 있음.
        //태그 해줘야함! - 어려운거 아니니까 까먹지 말쟈~!

        for(int i=0; i<=save.farmSaveDatas.Length-1; i++){       //int i=0; i <= save.cropSaveDatas.Length -1; i++    
            Vector3 position;
            position.x = save.farmSaveDatas[i].x;
            position.y = save.farmSaveDatas[i].y;
            position.z = save.farmSaveDatas[i].z;
            farms[i].transform.position = position;     //포지션 관련
                      
            Farm farm = farms[i].GetComponent<Farm>();
            farm.isDistroy = save.farmSaveDatas[i].isDistroy;  

            Instantiate(farms[i], new Vector3 (position.x, position.y, position.z), Quaternion.identity);   //-> 최초 Load에만 해야할 듯.  아니면 다 저장하고 삭제?
            Destroy(farms[i]);          
        }
    }

    public void FarmSaveDataDelete(){
        if("Farm Save.bin" != null){
            File.Delete("Farm Save.bin");
        }else{
            Debug.Log("Farm 저장 데이터가 없습니다.");
        }
    }
    
}
