using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour
{
    public Transform world;
    public BlockData[] blockTypes;   
    public Block[,] blocks;

    public int width = 5;       //5X5개로 설정이 되며 겹치게 나와서 결국에 보았을 때 10행이 형성됨.
    public int height = 5;
    //blockIndex값이 1이면 잔디가 나오게 설정을 해놓았음 - 혹시 식물에 따라 키우는 곳이 다를까봐 해놓은 설정임. 
    //1 - 35:23 - 삭제하지마시오 그리고 언제든지 block추가 가능합니다.
    public int blockIndex = 0;

    public CropData[] cropTypes;

    void Start()
    {
        blocks = new Block[height, width];
        GenerateFarm(width, height);
    }

    void Update()
    {

    }

    public void GenerateFarm(float width, float height)
    {
        for(int z=0; z<height; z++){
            for(int x=0; x<width; x++){

                //혹시 여기서 MissingPrefab이 뜬다면 해당 Scriptable Object에 가서 Prefab을 넣어주면 됨.
                Block block = new Block();
                BlockData blockData = blockTypes[blockIndex];
                
                block.id = blockIndex;
                block.name = blockData.name;
                block.x = x;
                block.z = z;
                block.blockPrefab = blockData.blockPrefab;
               
                CropValue crop = new CropValue();
                CropData cropData = cropTypes[0]; //배열 안에 0번쨰 있는 crop을 소환!
                    
                crop.maxGrowth = cropData.maxGrowth;
                crop.growthRate = cropData.growthRate;
                crop.maxHealth = cropData.maxHealth;
                crop.slotPrefab = cropData.CropPrefab;

                block.slot = crop;
                block.slot.slotType = BlockSlockType.CROP;
                

                blocks[z,x] = block;
                                  
            }
        }

        RenderFarm();
    }

    public void RenderFarm()
    {
        for(int z = 0; z<blocks.GetLength(0); z++){
            for(int x = 0; x < blocks.GetLength(1); x++)
            {
                Block block = blocks[z, x];
                Vector3 blockPos = new Vector3(block.x, 0, block.z);        //여기 값을 바꾸면 밭의 위치도 함께 바껴서 수박의 위치는 바뀌지 않음.
                //Vector3 cropPos = blockPos + new Vector3(-0.5f, 0.2f, 0.8f);
                

                //go의 의미는 밭이 생성되는 위치를 의미한다. Inmstantiate가 block.blockPrefab을 복제해서 Vector위치에 놓는다.
                GameObject go = Instantiate(block.blockPrefab, blockPos, Quaternion.identity);
                go.transform.SetParent(world);
                go.name = block.name +"  (" + x + ","+ 0 + "," + z + ")";      //형성되는 밭의 위치를 명확하게 보여주기 위해서 이걸 사용했음.

                for(int i=0; i<5; i++){  
                    for(int j=0; j<4; j++){        
                        GameObject blockSlot = Instantiate(block.slot.slotPrefab, blockPos + new Vector3(-4.5f + i, 0.18f, 1.0f + j), Quaternion.identity);     //bidge 추가 내용 2 - 40:16
                        blockSlot.transform.SetParent(go.transform);   

                        if(block.slot.slotType == BlockSlockType.CROP){
                            CropValue crop = (CropValue) block.slot;

                            CropLogic cropLogic = blockSlot.GetComponentInChildren<CropLogic>();
                            cropLogic.maxGrowth = crop.maxGrowth;
                            cropLogic.maxHealth = crop.maxHealth;
                            cropLogic.growthRate = crop.growthRate;
                            cropLogic.witheredPrefab = cropTypes[0].witheredPrefab;     //cropTypes안에 몇번쨰 것을 쓸 것인지 나중에 설정이 가능함.
                        }                         
                    }                   
                }
               
            }
        }
    }
}