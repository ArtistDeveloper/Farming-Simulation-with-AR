using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
   Inventory inven;

   // public GameObject inventoryPanel;
    //bool activeInventory=false;

    public Box[] boxes;
    public Transform boxHolder;
    int boxCount=5; 

/*
    [SerializeField] private Sprite Asparagus;
    [SerializeField] private Sprite Beet;
    [SerializeField] private Sprite Broccoli;
    [SerializeField] private Sprite Carrot;
    [SerializeField] private Sprite Lettuce;
    [SerializeField] private Sprite Onion;
    [SerializeField] private Sprite Potato;
    [SerializeField] private Sprite Pumkin;
    [SerializeField] private Sprite Watermelon;
    [SerializeField] private Sprite Wheat;

    private string spritename;

    private int boxneercan=0;

    private int Asparagus_count;
    private int Beet_count;
    private int Broccoli_count;
    private int Carrot_count;
    private int Lettuce_count;
    private int Onion_count;
    private int Potato_count;
    private int Pumkin_count;
    private int Watermelon_count;
    private int Wheat_count;


*/
    private void Start()
    {
        inven=Inventory.instance;  
        boxes = boxHolder.GetComponentsInChildren<Box>();
       
        for(int i = 0; i<boxes.Length; i++){
            if(i<boxCount){
                boxes[i].GetComponent<Button>().interactable=true;
            }else{
                boxes[i].GetComponent<Button>().interactable=false;
            }
        }
        
      //  inventoryPanel.SetActive(activeInventory);
  }

    private void Update()
    {
        for(int i = 0; i<boxes.Length; i++){
                if(i<boxCount){
                    boxes[i].GetComponent<Button>().interactable=true;
                }else{
                    boxes[i].GetComponent<Button>().interactable=false;
                }
        }

    }
/*

    private void Cropharvesting(string cropkind){
    
    //GameObject.FindWithTag("In");
    //CompareTag


        for(int i = 0; i<boxCount; i++){
            if(boxes[i].GetComponent<Button>().CompareTag(cropkind))    // tag주워서 비교=true 해당 태그 붙어있으니  
            {
               // cropkind+"_count"++;

            } 
            else
            {
                if(boxneercan)
                {



                }
                else
                {//남아있는 칸에 
                spritename=cropkind;
                boxes[i].GetComponent<Button>().image.sprite=cropkind;

                
                boxes[i].GetComponent<Button>().interactable=false;
                }
            }    
        }

    } 

*/

   public void AddBox(){
       
       boxCount++;
   }
}
