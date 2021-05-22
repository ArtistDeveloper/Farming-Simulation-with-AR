using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFarmKind : MonoBehaviour
{
    public GameObject farmPrefab;
    GameObject farm;

    public void OnClickButton_0(){
        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Farm farmScript = farm.GetComponent<Farm>();
        farmScript.GenerateFarm(1, 1, 0);
        Debug.Log("0번 버튼 선택됨.");
    }

    public void OnClickButton_1(){
        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Farm farmScript = farm.GetComponent<Farm>();
        farmScript.GenerateFarm(1, 1, 1);
        Debug.Log("1번 버튼 선택됨.");
    }

    public void OnClickButton_2(){
        farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Farm farmScript = farm.GetComponent<Farm>();
        farmScript.GenerateFarm(1, 1, 2);
        Debug.Log("2번 버튼 선택됨.");
    }

}
