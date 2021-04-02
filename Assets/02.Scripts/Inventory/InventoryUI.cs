using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
//using System.Windows.forms;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Inventory inven;

    public GameObject InventoryBG;

    public Box[] boxes;
    public Transform boxHolder;

    private void Start()
    {
        inven=Inventory.instance;
        boxes = boxHolder.GetComponentsInChildren<Box>();
        inven.OnBoxCountChang += BoxChange;
    }

    private void BoxChange(int val){
        for(int i = 0; i<boxes.Length; i++){
            if(i<inven.BoxCount){
                boxes[i].GetComponent<Button>().interactable=true;
            }else{
                boxes[i].GetComponent<Button>().interactable=false;
            }
        }
    }

    private void Update()
    {
        
    }
    public void AddBox(){
        inven.BoxCount++;
    }
}
