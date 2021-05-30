using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellCount : MonoBehaviour
{
    
    //public UnityEngine.UI.Text SellcountText;
    [SerializeField] private Text SellcountText;//증감개수
    [SerializeField] private Text DiamondText; //sell창 다이아
    [SerializeField] private Text DiaMain;      //메인다이아

    private int ChageCount;                 //증감개수변화
 
    private int ChageDia;                   
    private int price;
    private int Maxcount; //원래개수

    private int Diamondadd;

    private CropCountSave cropCountSave;

    [SerializeField] GameObject Sellckd;

    
    //판매개수
    private int Sellcount;
    //계산개수
    private int Minuscount;
    

    public void DownClick(){
        
        ChageCount = int.Parse(SellcountText.text);

        //ChageDia=int.Parse(DiamondText.text);

        if(ChageCount==1){
            SellcountText.text="";
            SellcountText.text=ChageCount.ToString();

            DiamondText.text="";
            DiamondText.text=price.ToString();
        }else{
            ChageCount -= 1;
            SellcountText.text="";
            SellcountText.text=ChageCount.ToString();
            
            ChageDia = ChageDia - price;
            DiamondText.text="";
            DiamondText.text=ChageDia.ToString();
        }
        
    }

    
    void Start()
    {
        Maxcount = int.Parse(SellcountText.text);
        SellcountText.text="1";
        

        price = int.Parse(DiamondText.text);
        //ChageDia = price*Maxcount;
        DiamondText.text = price.ToString();

    }

    public void UpClick(){
        
        ChageCount = int.Parse(SellcountText.text);

        if(Maxcount==ChageCount)
        {
            SellcountText.text="";
            SellcountText.text=Maxcount.ToString();
            
            DiamondText.text="";
            DiamondText.text=ChageDia.ToString();
        }else
        {
            ChageCount += 1;
            SellcountText.text="";
            SellcountText.text=ChageCount.ToString();


            ChageDia = ChageCount * price;
            DiamondText.text="";
            DiamondText.text=ChageDia.ToString();
        }
              


    }

    void Update(){

    }


    public void WatermelonSell()
    {
        //수박 개수 감소
        Sellcount=ChageCount;

        Minuscount=Maxcount-Sellcount;

        PlayerPrefs.SetInt("watermelon",Minuscount);

        SellcountText.text=Minuscount.ToString();

        //다이아 증가
        Diamondadd=int.Parse(DiaMain.text);
        Diamondadd = Diamondadd+int.Parse(DiamondText.text);
        DiaMain.text=Diamondadd.ToString();

        Sellckd.SetActive(false);

    }
    public void CarrotSell()
    {
        //당근 개수 감소
        Sellcount=ChageCount;

        Minuscount=Maxcount-Sellcount;

        PlayerPrefs.SetInt("Carrot",Minuscount);

        SellcountText.text=Minuscount.ToString();

        //다이아 증가
        Diamondadd=int.Parse(DiaMain.text);
        Diamondadd = Diamondadd+int.Parse(DiamondText.text);
        DiaMain.text=Diamondadd.ToString();

        Sellckd.SetActive(false);

    }
    public void PotatoSell()
    {
        //감자 개수 감소
        
        Sellcount=ChageCount;

        Minuscount=Maxcount-Sellcount;

        PlayerPrefs.SetInt("Potato",Minuscount);

        SellcountText.text=Minuscount.ToString();
        
        //다이아 증가
        Diamondadd=int.Parse(DiaMain.text);
        Diamondadd = Diamondadd+int.Parse(DiamondText.text);
        DiaMain.text=Diamondadd.ToString();

        Sellckd.SetActive(false);

    }
    public void AsparagusSell()
    {
        //아스파 개수 감소
        Sellcount=ChageCount;

        Minuscount=Maxcount-Sellcount;

        PlayerPrefs.SetInt("Asparagus",Minuscount);

        SellcountText.text=Minuscount.ToString();
        
        //다이아 증가
        Diamondadd=int.Parse(DiaMain.text);
        Diamondadd = Diamondadd+int.Parse(DiamondText.text);
        DiaMain.text=Diamondadd.ToString();

        Sellckd.SetActive(false);

    }
    public void BeetSell()
    {
        //사탕무 개수 감소
        Sellcount=ChageCount;

        Minuscount=Maxcount-Sellcount;

        PlayerPrefs.SetInt("Beet",Minuscount);

        SellcountText.text=Minuscount.ToString();
        
        //다이아 증가
        Diamondadd=int.Parse(DiaMain.text);
        Diamondadd = Diamondadd+int.Parse(DiamondText.text);
        DiaMain.text=Diamondadd.ToString();

        Sellckd.SetActive(false);

    }
    public void PumkinSell()
    {
        //호박 개수 감소
        Sellcount=ChageCount;

        Minuscount=Maxcount-Sellcount;

        PlayerPrefs.SetInt("Pumkin",Minuscount);

        SellcountText.text=Minuscount.ToString();
        
        //다이아 증가
        Diamondadd=int.Parse(DiaMain.text);
        Diamondadd = Diamondadd+int.Parse(DiamondText.text);
        DiaMain.text=Diamondadd.ToString();

        Sellckd.SetActive(false);

    }
    public void OnionSell()
    {
        //양파 개수 감소
        Sellcount=ChageCount;

        Minuscount=Maxcount-Sellcount;

        PlayerPrefs.SetInt("Onion",Minuscount);

        SellcountText.text=Minuscount.ToString();
        
        //다이아 증가
        Diamondadd=int.Parse(DiaMain.text);
        Diamondadd = Diamondadd+int.Parse(DiamondText.text);
        DiaMain.text=Diamondadd.ToString();

        Sellckd.SetActive(false);

    }
    public void LettuceSell()
    {
        //양상추 개수 감소
        Sellcount=ChageCount;

        Minuscount=Maxcount-Sellcount;

        PlayerPrefs.SetInt("Lettuce",Minuscount);

        SellcountText.text=Minuscount.ToString();
        
        //다이아 증가
        Diamondadd=int.Parse(DiaMain.text);
        Diamondadd = Diamondadd+int.Parse(DiamondText.text);
        DiaMain.text=Diamondadd.ToString();

        Sellckd.SetActive(false);

    }
    public void WheatSell()
    {
        //밀 개수 감소
        Sellcount=ChageCount;

        Minuscount=Maxcount-Sellcount;

        PlayerPrefs.SetInt("Wheat",Minuscount);

        SellcountText.text=Minuscount.ToString();
        
        //다이아 증가
        Diamondadd=int.Parse(DiaMain.text);
        Diamondadd = Diamondadd+int.Parse(DiamondText.text);
        DiaMain.text=Diamondadd.ToString();

        Sellckd.SetActive(false);

    }
    public void BroccoliSell()
    {
        //브로콜리 개수 감소
        Sellcount=ChageCount;

        Minuscount=Maxcount-Sellcount;

        PlayerPrefs.SetInt("Broccoli",Minuscount);
        
        SellcountText.text=Minuscount.ToString();
        
        //다이아 증가
        Diamondadd=int.Parse(DiaMain.text);
        Diamondadd = Diamondadd+int.Parse(DiamondText.text);
        DiaMain.text=Diamondadd.ToString();

        Sellckd.SetActive(false);

    }

    
}
