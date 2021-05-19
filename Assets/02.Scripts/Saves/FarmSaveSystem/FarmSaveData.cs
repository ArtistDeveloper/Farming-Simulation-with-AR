using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//얘가 Data로 치면 된다.
[System.Serializable]
public class FarmSaveData
{
   //현재 저장하는 Data - 위치, 파괴가 되었는지 아닌지(Crop이 다 재배되었는지 아닌지.)
   //
   public float[] position;

   public float x;
   public float y;
   public float z;

   public bool isDistroy;
   
   public FarmSaveData(Farm B){
      x = B.transform.position.x;
      y = B.transform.position.y;
      z = B.transform.position.z;

      position = new float[3];
      position[0] = x;
      position[1] = y;
      position[2] = z;

      isDistroy = B.isDistroy;
   }
}
