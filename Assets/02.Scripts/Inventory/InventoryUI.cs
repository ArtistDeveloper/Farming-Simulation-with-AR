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
   public void AddBox(){
       
       boxCount++;
   }
}
