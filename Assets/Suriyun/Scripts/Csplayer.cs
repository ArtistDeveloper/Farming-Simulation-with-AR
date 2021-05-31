using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Csplayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void Awake(){
        StartCoroutine(DownUpdate());
    }
    
    private IEnumerator DownUpdate()
    {
        while(true)
        {
            if(Input.GetMouseButtonDown(0))
            {   
            Vector3 pos = Input.mousePosition;
            pos.z = 10;
            Vector3 target = Camera.main.ScreenToWorldPoint(pos);
            print("target" + target);          
            transform.LookAt(target);
            }
            yield return new WaitForSeconds(10f);
        }
    } 
    /*void Update()
    {
        if(Input.GetMouseButtonDown(0)){   
            Vector3 pos = Input.mousePosition;
            pos.z = 10;
            Vector3 target = Camera.main.ScreenToWorldPoint(pos);
            print("target" + target);          
            transform.LookAt(target);
        }
    }*/
}
