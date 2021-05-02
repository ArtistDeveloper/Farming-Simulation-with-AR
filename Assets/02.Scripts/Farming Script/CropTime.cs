using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


//지금 remainGrowTimed에 지나고 난 다음 시간이 들어감
//

public class CropTime : Crop       //QuitTime저장하는거는 있어야할거 같음.
{
    //이 이후에는 시간 관련 변수들
    private DateTime m_AppQuitTime = new DateTime(1970, 1, 1).ToLocalTime();  //이건 나가는 시간이고 꼭 필요함!
    private Coroutine m_RechargeTimerCoroutine = null;
    public int timeMaxGrowInterval = 60; //다 자르는데 걸리는 시간 - 일단 30초로 잡음. 
    public int remainGrowTime = 60;         //계속 다시 60이 된다.

    private CropState cropState;
    private CropLogic cropLogic;

    void Awake(){
        cropState = gameObject.GetComponent<CropState>();       //대가리 계산에서는 빼도 됌.   
    }

    void Start(){
        OnApplicationFocus(true);
    }
    
    //게임 초기화(Awake), 중간 이탈, 중간 복귀 시 실행되는 함수
    public void OnApplicationFocus(bool value){
        if (value)
        {   
            //혹시  SaveFile이 없으면 생기는 버그도 고칠 수 있으면 고치자.
            LoadCrop();     //이까진 됐음.      
            LoadAppQuitTime();      //그래서 그만둔 시간만 들고옴.        
            SetRechargeScheduler();
            CropSaveDataDelete();
        }
        else
        {
            SaveCrop();
            SaveAppQuitTime();
        }
    }

    //게임 종료 시 실행되는 함수
    public void OnApplicationQuit()
    {
        SaveCrop();
        SaveAppQuitTime();
    }

    public bool SaveAppQuitTime()           //나간 시간 저장
    {
        //Debug.Log("SaveAppQuitTime");
        bool result = false;
        try
        {
            var appQuitTime = DateTime.Now.ToLocalTime().ToBinary().ToString();     
            PlayerPrefs.SetString("AppQuitTime", appQuitTime);
            PlayerPrefs.Save();

            Debug.Log("Saved AppQuitTime : " + DateTime.Now.ToLocalTime().ToString());
            result = true;
        }
        catch (System.Exception e)
        {
            Debug.LogError("SaveAppQuitTime Failed (" + e.Message + ")");
        }
        return result;
    }

    public bool LoadAppQuitTime()       
    {
        bool result = false;
        try
        {
            if (PlayerPrefs.HasKey("AppQuitTime"))      //처음에는 없어도 ㄱㅊ 노상관임.
            {
                var appQuitTime = string.Empty;
                appQuitTime = PlayerPrefs.GetString("AppQuitTime");
                m_AppQuitTime = DateTime.FromBinary(Convert.ToInt64(appQuitTime));      //바이너리 값을 불러온다.
            }

            result = true;
        }
        catch (System.Exception e)
        {
            Debug.LogError("LoadAppQuitTime Failed (" + e.Message + ")");
        }
        return result;
    }

    public void SetRechargeScheduler(Action onFinish = null)
    {
        if (m_RechargeTimerCoroutine != null)
        {
            //Debug.Log("set에서 null인데 뭐지>?"); //아님
            StopCoroutine(m_RechargeTimerCoroutine);
        }

        if(remainGrowTime != timeMaxGrowInterval){     //m_AppQuitTime을 설정해보는건 어떨까? 그럼?
            var timeDifferenceInSec = (int)((DateTime.Now.ToLocalTime() - m_AppQuitTime).TotalSeconds);    //지금 시간이랑 앱을 껐을 떄의 시간을 뺀 값이 들어가게 된다.
            var remainTime = remainGrowTime - timeDifferenceInSec;   
            Debug.Log("킹준수 timeDiff계산해서 나온 remainTime이야  " + remainTime);
            if (remainTime <= timeMaxGrowInterval)      
            {
                m_RechargeTimerCoroutine = StartCoroutine(DoRechargeTimer(remainTime, onFinish));
            }
        }else       //remainGrowTime == timeMaxGrowInterval로 새로 생겼다는 의미
        {
            var remainTime = remainGrowTime;        //이게 들어가도 상관이 없는게 결국 Awake에서 timeMax로 조절을 해줘서 상관없음.
            if (remainTime <= timeMaxGrowInterval)      
            {
                m_RechargeTimerCoroutine = StartCoroutine(DoRechargeTimer(remainTime, onFinish));
            }
        }
    }

    public int getRemainGrowTime(){
        return remainGrowTime;
    }
    public int getTimeMaxGrowInterval(){
        return timeMaxGrowInterval;
    }

        
    private IEnumerator DoRechargeTimer(int remainTime, Action onFinish = null)
    {
        //Debug.Log("DoRechargeTimer");
        if (remainTime <= 0)            //즉 남은시간이 없다. 다 자랐다.
        {
            remainGrowTime = 0;
        }
        else //remainTime > 0
        {
            remainGrowTime = remainTime;
        }
      
        while (remainGrowTime > 0)        //다 자랄때까지 시간이 남았을 때 돌리는 while이고 1초씩 기다리면서 1f씩 줄인다. 
        {
            Debug.Log("CropGrowingTimer : " + remainGrowTime + "s");
            remainGrowTime -= 1;
            yield return new WaitForSeconds(1f);        //결국 마지막에는 remainGrowTime = 0이 된다.
        }

        if(remainGrowTime <= 0){
            if(cropState != null){
                cropState.GrowDone();         
            }else{
                Debug.Log("cropState를 들고오지 못함");     //못들고온다 왜? - 이제 들고옴 - Awake에서 들고왔기 때문임.
            }
        }
    }
}
