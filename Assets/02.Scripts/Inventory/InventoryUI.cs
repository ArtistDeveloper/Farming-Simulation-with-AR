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

    //이미지 보관
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

    private string spritename;  //이미지이름

    private int boxneercan=0;  //사용 가능한 칸
    
    //작물 개수 문자 변환
    private string Asparagus_Text;
    private string Beet_Text;
    private string Broccoli_Text;
    private string Carrot_Text;
    private string Lettuce_Text;
    private string Onion_Text;
    private string Potato_Text;
    private string Pumkin_Text;
    private string Watermelon_Text;
    private string Wheat_Text;


    //작물 개수 보관
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

    [SerializeField] GameObject qnwhr;

  
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

    public void Cropharvesting(string cropkind){
    
    //GameObject.FindWithTag("In");
    //CompareTag
    // cropkind+"_count"++;

        for(int i = 0; i<boxCount; i++){
            if(boxes[i].GetComponent<Button>().CompareTag(cropkind))    // tag주워서 비교=true 해당 태그 붙어있으니  
            {
                Debug.Log("있어!");

                if(cropkind=="Watermelon"){  
                    Watermelon_count = PlayerPrefs.GetInt("Watermelon_Count", 0);
                    Watermelon_Text = Watermelon_count.ToString("0");
                }
            
                if(cropkind=="Carrot"){
                    Carrot_count = PlayerPrefs.GetInt("Carrot_Count", 0);
                    Carrot_Text = Carrot_count.ToString("0");
                }

                if(cropkind=="Potato"){
                    Potato_count = PlayerPrefs.GetInt("Potato_Count", 0);
                    Potato_Text=Potato_count.ToString("0");
                }

                if(cropkind=="Asparagus"){
                    Asparagus_count = PlayerPrefs.GetInt("Asparagus_Count", 0);
                    Asparagus_Text=Asparagus_count.ToString("0");
                }            

                if(cropkind=="Beet"){
                    Beet_count = PlayerPrefs.GetInt("Beet_Count", 0);
                    Beet_Text=Beet_count.ToString("0");
                }

                if(cropkind=="Pumkin"){
                    Pumkin_count = PlayerPrefs.GetInt("Pumkin_Count", 0);
                    Pumkin_Text=Pumkin_count.ToString("0");
                }

                if(cropkind=="Onion"){
                    Onion_count = PlayerPrefs.GetInt("Onion_Count", 0);
                    Onion_Text=Onion_count.ToString("0");
                }

                if(cropkind=="Lettuce"){
                    Lettuce_count = PlayerPrefs.GetInt("Lettuce_Count", 0);
                    Lettuce_Text=Lettuce_count.ToString("0");
                }

                if(cropkind=="Wheat"){
                    Wheat_count = PlayerPrefs.GetInt("Wheat_Count", 0);
                    Wheat_Text=Wheat_count.ToString("0");
                }

                if(cropkind=="Broccoli"){
                    Broccoli_count = PlayerPrefs.GetInt("Broccoli_Count", 0);
                    Broccoli_Text=Broccoli_count.ToString("0");
                }

            } 
            else
            {
                if(boxneercan==boxCount)
                {
                    qnwhr.SetActive(true);
                }
                else
                {//남아있는 칸에 
                    for(int j = 0; j<boxCount; j++){
                        if(boxes[j].GetComponent<Button>().CompareTag("In")){
                            if(cropkind=="Asparagus")
                            {
                                boxes[j].GetComponent<Button>().image.sprite=Asparagus;
                                boxes[j].GetComponent<Button>().tag="Asparagus";
                                boxneercan++;
                                j=boxCount;
                            }
                            else if(cropkind=="Beet")
                            {
                                boxes[j].GetComponent<Button>().image.sprite=Beet;
                                boxes[j].GetComponent<Button>().tag="Beet";
                                boxneercan++;
                                j=boxCount;
                            }
                            else if(cropkind=="Broccoli")
                            {
                                boxes[j].GetComponent<Button>().image.sprite=Broccoli;
                                boxes[j].GetComponent<Button>().tag="Broccoli";
                                boxneercan++;
                                j=boxCount;
                            }
                            else if(cropkind=="Carrot")
                            {
                                boxes[j].GetComponent<Button>().image.sprite=Carrot;
                                boxes[j].GetComponent<Button>().tag="Carrot";
                                boxneercan++;
                                j=boxCount;
                            }
                            else if(cropkind=="Lettuce")
                            {
                                boxes[j].GetComponent<Button>().image.sprite=Lettuce;
                                boxes[j].GetComponent<Button>().tag="Lettuce";
                                boxneercan++;
                                j=boxCount;
                            }
                            else if(cropkind=="Onion")
                            {
                                boxes[j].GetComponent<Button>().image.sprite=Onion;
                                boxes[j].GetComponent<Button>().tag="Onion";
                                boxneercan++;
                                j=boxCount;
                            }
                            else if(cropkind=="Potato")
                            {
                                boxes[j].GetComponent<Button>().image.sprite=Potato;
                                boxes[j].GetComponent<Button>().tag="Potato";
                                boxneercan++;
                                j=boxCount;
                            }
                            else if(cropkind=="Pumkin")
                            {
                                boxes[j].GetComponent<Button>().image.sprite=Pumkin;
                                boxes[j].GetComponent<Button>().tag="Pumkin";
                                boxneercan++;
                                j=boxCount;
                            }
                            else if(cropkind=="Watermelon")
                            {
                                boxes[j].GetComponent<Button>().image.sprite=Watermelon;
                                boxes[j].GetComponent<Button>().tag="Watermelon";
                                boxneercan++;
                                j=boxCount;
                            }
                            else if(cropkind=="Wheat")
                            {
                                boxes[j].GetComponent<Button>().image.sprite=Wheat;
                                boxes[j].GetComponent<Button>().tag="Wheat";
                                boxneercan++;
                                j=boxCount;
                            }
                        }
                
                    }
                
                }

            }    
        }

    } // Cropharvesting 끝

    public void WatermelonSell(){

        if(Watermelon_count<0){
            
        }





    }



   public void AddBox(){
       
       boxCount++;
   }
}
