using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//얘가 Data로 치면 된다.
[System.Serializable]
public class CropSaveData
{
   //시간
   public int remainGrowTimeSave;
      

   public CropSaveData(CropTime B){
      //시간 저장
      remainGrowTimeSave = B.remainGrowTime;
      //이제 PlayerPrefs로 시간저장이 아닌 이걸로 저장하는 걸 해야한다.
   }
}
