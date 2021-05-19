using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabCr : MonoBehaviour
{
    [SerializeField] private Text buildText;
    [SerializeField] public GameObject ckd;

    public GameObject ckdrh;
    public GameObject dnf1;
    public GameObject dnf2;
    public GameObject dnf3;
    public GameObject qkx;
    public GameObject wkehdck;
    public GameObject anfxodzm;


    public void OnYes(){
        
       // if(buildText.text!= null){  ckd.SetActive(false);     }
        if(buildText.text=="창고를 설치하시겠습니까?"){
            ckd.SetActive(false);
            Debug.Log(buildText.text);

            //GameObject.Find("InventoryBBG").GetComponent<InventoryUI>().AddBox();
            //GameObject.Find("InventoryBBG").GetComponent<InventoryUI>.AddBox();
            //GameObject.FindGameObjectWithTag("BBG").GetComponent<InventoryUI>();
            //골든벨 브금 딴딴따딴
        }
        else if(buildText.text=="울타리1을 설치하시겠습니까?"){

            Instantiate(dnf1, new Vector3(0,0,0), Quaternion.identity);
            ckd.SetActive(false);

        }
        else if(buildText.text=="울타리2을 설치하시겠습니까?"){

            Instantiate(dnf2, new Vector3(0,0,0), Quaternion.identity);
            ckd.SetActive(false);

        }
        else if(buildText.text=="울타리3을 설치하시겠습니까?"){

            Instantiate(dnf3, new Vector3(0,0,0), Quaternion.identity);
            ckd.SetActive(false);

        }
        else if(buildText.text=="밭을 설치하시겠습니까?"){

            Instantiate(qkx, new Vector3(0,0,0), Quaternion.identity);
            ckd.SetActive(false);

        }
        else if(buildText.text=="자동차를 설치하시겠습니까?"){

            Instantiate(wkehdck, new Vector3(0,0,0), Quaternion.identity);
            ckd.SetActive(false);

        }else if(buildText.text=="물탱크를 설치하시겠습니까?"){

            Instantiate(anfxodzm, new Vector3(0,0,0), Quaternion.identity);
            ckd.SetActive(false);

        }
        else{
            Debug.Log("존재하지 않아.");
        }



    }


}
