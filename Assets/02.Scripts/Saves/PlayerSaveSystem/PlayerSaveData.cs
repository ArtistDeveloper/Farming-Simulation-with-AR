using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//얘가 Data로 치면 된다.
[System.Serializable]
public class PlayerSaveData
{
   public int HP;
   public float AP;

   public float[] position;

   public float x;
   public float y;
   public float z;
   
   public PlayerSaveData(Player B){
      HP = B.HealthPoint;
      AP = B.AttackPoint;

      x = B.transform.position.x;
      y = B.transform.position.y;
      z = B.transform.position.z;

      position = new float[3];
      position[0] = x;
      position[1] = y;
      position[2] = z;
   }
}
