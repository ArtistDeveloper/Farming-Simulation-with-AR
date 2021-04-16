using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//현재 고쳐야 할 점들 숫자는 우선순위와 상관이 없다.
//1. 실시간으로 바꿔야한다.
//2. 물이 없을 때 Cube, 다 자랐을 때 Cube, 썩었을 때  Cube이 3가지가 필요하다.
//3. 

public class CropLogic : MonoBehaviour
{
    public float maxGrowth = 100f;
    public float growthLevel = 0;
    public float growthRate = 10f;      //자라는 속도임.
    public float maxHealth = 100.0f;

    public GameObject witheredPrefab;

    private bool wither = false;
    public float health = 100.0f;
    public float witerRate = 10.0f;
    private DirtBlock dirtBlock;

    void Start()
    {
        dirtBlock = transform.parent.GetComponent<DirtBlock>();
        health = maxHealth;
    }
    
    // Update is called once per frame
    void Update()
    {
        //시드는 것임.
        if(wither)
        {          
             health -= witerRate * Time.deltaTime;

            if(health <= 0 ){     
                if(witheredPrefab != null)
                {
                    for(int i=0; i<5; i++){
                        for(int j=0; j<4; j++){
                            //썩은 Crop나타나게 하는 코드.
                            GameObject go = Instantiate(witheredPrefab, transform.position + new Vector3(i,0,j), Quaternion.identity);
                            go.transform.SetParent(transform.parent.parent);
                            go.GetComponentInChildren<Transform>().localScale = transform.localScale;
                        }
                    }
                }else{
                    Debug.LogError("withered Prefab이 설정되지 않음.");
                }     
                dirtBlock.CropWither();
            }              
        }else
        {
            if(health < maxHealth){
                health += (growthRate / 2) * Time.deltaTime;        //여기 있는 숫자를 키우면 health 올라가는 속도가 느려짐. 일단 난 빠르게 함.
            }
        }

        if(health >= maxHealth){
            health = maxHealth;
        }

        if(growthLevel >= maxGrowth){
            growthLevel = maxGrowth;
            return;
        }else{
        //작물이 점점 커지는 것.
            ScaleCrop();
        }

        if(growthLevel >= 100.0f && health != 0){
            //Debug.Log("다 자람");  //근데 모든 객체에 모두 다 작용을 한다. 1번만 실행되는 상태 그렇다면 모든 수박마다 다 완료 표시가 뜬다. 어디다 해야할까?
            //GameObject done = Instantiate(growDone, transform.position, Quaternion.identity);


        }

    }

    void ScaleCrop()
    {
        growthLevel += growthRate * Time.deltaTime;
        Vector3 cropScale = new Vector3(1, 1, 1) * (growthLevel /100);
        gameObject.transform.localScale = cropScale;
    }

    public void StartWither()
    {
        // if(waterCount == 0){
        //     //GameObject waterPlz = Instantiate(waterImage, new Vector3(this.transform.position.x -2.5f, this.transform.position.y + 2.5f, this.transform.position.z + 2.5f), Quaternion.identity);
        // } 
        wither = true;
    }

    public void StopWither()
    {
        wither = false;
    }


}
