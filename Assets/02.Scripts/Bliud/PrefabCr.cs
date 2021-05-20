using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabCr : MonoBehaviour
{
    [SerializeField] private Text buildText;
    [SerializeField] private Text DiaText;
    [SerializeField] public GameObject ckd;
    [SerializeField] public GameObject dkseho;

    public GameObject dnf1;
    public GameObject dnf2;
    public GameObject dnf3;
    public GameObject qkx;
    public GameObject wkehdck;
    public GameObject anfxodzm;

    public GameObject ekfrwkd;
    //public GameObject

    
    [SerializeField] private Text DiamainText;
    private int ChageDia;
    private int useDia;    


    public void OnYes(){
      
       if(buildText.text=="울타리1을 설치하시겠습니까?")
       {
         useDia = int.Parse(DiamainText.text);
           if(useDia>1000)
           {
                Instantiate(dnf1, new Vector3(0,0,0), Quaternion.identity); 
                ChageDia=useDia-1000;
                DiamainText.text="";
                DiamainText.text=ChageDia.ToString();
                ckd.SetActive(false);
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }
        
        if(buildText.text=="울타리2을 설치하시겠습니까?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>2000)
           {
                Instantiate(dnf2, new Vector3(0,0,0), Quaternion.identity); 
                ChageDia=useDia-2000;
                DiamainText.text="";
                DiamainText.text=ChageDia.ToString();
                ckd.SetActive(false);
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }
        
        if(buildText.text=="울타리3을 설치하시겠습니까?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>3000)
           {
                Instantiate(dnf3, new Vector3(0,0,0), Quaternion.identity); 
                ChageDia=useDia-3000;
                DiamainText.text="";
                DiamainText.text=ChageDia.ToString();
                ckd.SetActive(false);
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }
        
        if(buildText.text=="밭을 설치하시겠습니까?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>500)
           {
                Instantiate(qkx, new Vector3(0,0,0), Quaternion.identity); 
                ChageDia=useDia-500;
                DiamainText.text="";
                DiamainText.text=ChageDia.ToString();
                ckd.SetActive(false);
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }
        
        if(buildText.text=="자동차를 설치하시겠습니까?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>200000)
           {
                Instantiate(wkehdck, new Vector3(0,0,0), Quaternion.identity); 
                ChageDia=useDia-200000;
                DiamainText.text="";
                DiamainText.text=ChageDia.ToString();
                ckd.SetActive(false);
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }
        
        if(buildText.text=="물탱크를 설치하시겠습니까?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>50000)
           {
                Instantiate(anfxodzm, new Vector3(0,0,0), Quaternion.identity); 
                ChageDia=useDia-50000;
                DiamainText.text="";
                DiamainText.text=ChageDia.ToString();
                ckd.SetActive(false);
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }
        
        if(buildText.text=="닭장을 설치하시겠습니까?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>5000)
           {
                Instantiate(ekfrwkd, new Vector3(0,0,0), Quaternion.identity); 
                ChageDia=useDia-5000;
                DiamainText.text="";
                DiamainText.text=ChageDia.ToString();
                ckd.SetActive(false);
            }
            else
            {
                dkseho.SetActive(true);
                ckd.SetActive(false); 
            }
        }
        /*else if(buildText.text=="물탱크를 설치하시겠습니까?"){

            Instantiate(anfxodzm, new Vector3(0,0,0), Quaternion.identity);
            ckd.SetActive(false);

        }*/


        else{
            Debug.Log("존재하지 않아.");
        }



    }


}
