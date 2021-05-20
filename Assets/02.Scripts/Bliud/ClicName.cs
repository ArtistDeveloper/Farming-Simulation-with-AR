using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClicName : MonoBehaviour
{
    [SerializeField] private Text NameText;

    public void Onclickull1(){ NameText.text="울타리1을 설치하시겠습니까?"; }
    public void Onclickull2(){ NameText.text="울타리2을 설치하시겠습니까?"; }
    public void Onclickull3(){ NameText.text="울타리3을 설치하시겠습니까?"; }
     public void Onclickckdrh(){ NameText.text="창고를 설치하시겠습니까?"; }
    public void Onclickqkx(){ NameText.text="밭을 설치하시겠습니까?"; }
    public void Onclickck(){ NameText.text="자동차를 설치하시겠습니까?"; }
    public void OnWater(){ NameText.text="물탱크를 설치하시겠습니까?"; }

    public void Onekfwkd(){ NameText.text="닭장을 설치하시겠습니까?"; }

    //public void OnWater(){ NameText.text="물탱크를 설치하시겠습니까?"; }
}
