using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoadQuitTime : MonoBehaviour
{
    void Awake(){        //InEnable에서 한번 더 AppQuitTime저장.    안됌.
        if(PlayerPrefs.HasKey("AppQuitTime")){
            var appQuitTime = DateTime.Now.ToLocalTime().ToBinary().ToString();
            PlayerPrefs.SetString("AppQuitTime", appQuitTime);
            PlayerPrefs.Save();
        }
    }
}
