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
    public GameObject wkehdck;
    public GameObject anfxodzm;

    public GameObject ekfrwkd;
    //public GameObject

    
    [SerializeField] private Text DiamainText;
    private int ChageDia;
    private int useDia;    


    public GameObject farmPrefab;
    GameObject farm;

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

        //-------------------------------------------------------------

         if(buildText.text=="아스파라거스를 심을까요?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>500)
           {
                farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                Farm farmScript = farm.GetComponent<Farm>();
                farmScript.GenerateFarm(1, 1, 0);

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

         if(buildText.text=="사탕무를 심을까요?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>1000)
           {
                farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                Farm farmScript = farm.GetComponent<Farm>();
                farmScript.GenerateFarm(1, 1, 1);
                
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

         if(buildText.text=="브로콜리를 심을까요?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>2000)
           {
                farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                Farm farmScript = farm.GetComponent<Farm>();
                farmScript.GenerateFarm(1, 1, 2);
                
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

        
         if(buildText.text=="당근을 심을까요?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>3000)
           {
                farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                Farm farmScript = farm.GetComponent<Farm>();
                farmScript.GenerateFarm(1, 1, 3);
                
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

        
         if(buildText.text=="양상추를 심을까요?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>4000)
           {
                farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                Farm farmScript = farm.GetComponent<Farm>();
                farmScript.GenerateFarm(1, 1, 4);
                
                ChageDia=useDia-4000;
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

        
         if(buildText.text=="양파를 심을까요?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>5000)
           {
                farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                Farm farmScript = farm.GetComponent<Farm>();
                farmScript.GenerateFarm(1, 1, 5);
                
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

        if(buildText.text=="감자를 심을까요?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>6000)
           {
                farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                Farm farmScript = farm.GetComponent<Farm>();
                farmScript.GenerateFarm(1, 1, 6);
                
                ChageDia=useDia-6000;
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

         if(buildText.text=="호박을 심을까요?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>7000)
           {
                farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                Farm farmScript = farm.GetComponent<Farm>();
                farmScript.GenerateFarm(1, 1, 7);
                
                ChageDia=useDia-7000;
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

         if(buildText.text=="수박을 심을까요?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>8000)
           {
                farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                Farm farmScript = farm.GetComponent<Farm>();
                farmScript.GenerateFarm(1, 1, 8);
                
                ChageDia=useDia-8000;
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

         if(buildText.text=="밀을 심을까요?"){

         useDia = int.Parse(DiamainText.text);
           if(useDia>9000)
           {
                farm = Instantiate(farmPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                Farm farmScript = farm.GetComponent<Farm>();
                farmScript.GenerateFarm(1, 1, 9);
                 
                ChageDia=useDia-9000;
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


        else{
            Debug.Log("존재하지 않아.");
        }



    }


}
