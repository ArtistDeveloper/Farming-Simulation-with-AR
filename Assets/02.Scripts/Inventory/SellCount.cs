using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellCount : MonoBehaviour
{
    
    //public UnityEngine.UI.Text SellcountText;
    [SerializeField] private Text SellcountText;
    [SerializeField] private Text DiamondText;
    private int ChageCount;
    //private int MaxCount;
    private int ChageDia;
    private int price;
    

    public void UpClick(){

        ChageCount = int.Parse(SellcountText.text);

        ChageCount +=1;
        SellcountText.text="";
        SellcountText.text=ChageCount.ToString();

        

        //작물 최대 갯수 받아올때 사용
       /* ChageCount = int.Parse(SellcountText.text);

        if(ChageCount==MaxCount){
            SellcountText.text="";
            SellcountText.text=ChageCount.ToString();
        }else{
            ChageCount +=1;
            SellcountText.text="";
            SellcountText.text=ChageCount.ToString();
        }*/

        ChageDia = int.Parse(DiamondText.text);
        
        ChageDia = ChageDia + price;
        DiamondText.text="";
        DiamondText.text=ChageDia.ToString();


    }
    public void DownClick(){
        
        ChageCount = int.Parse(SellcountText.text);

        ChageDia=int.Parse(DiamondText.text);

        if(ChageCount==1){
            SellcountText.text="";
            SellcountText.text=ChageCount.ToString();

            DiamondText.text="";
            DiamondText.text=price.ToString();
        }else{
            ChageCount -= 1;
            SellcountText.text="";
            SellcountText.text=ChageCount.ToString();
            
            ChageDia = ChageDia-price;
            DiamondText.text="";
            DiamondText.text=ChageDia.ToString();
        }
        
    }

    public void Zero(){
        SellcountText.text="1";
        price = int.Parse(DiamondText.text);

    }
   
    void Start()
    {
        //SellcountText.text="1";
        price = int.Parse(DiamondText.text);

    }

    void Update()
    {
        

        
    }

    public void ClickSell(){



    }
}
