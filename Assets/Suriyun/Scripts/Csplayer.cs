using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Csplayer : MonoBehaviour
{
    private Camera cam;
    private GameObject target;

    private MoveFarmer moveFarmer;
    private NavMeshAgent farmer;

    //private IEnumerator coroutine;

    float timer;
    int waitingTime;

    // Start is called before the first frame update
    void Start()
    {   
        // moveFarmer.GetComponent<Farmer>();
        moveFarmer = gameObject.GetComponent<MoveFarmer>();
        farmer = moveFarmer.Farmer;
        
        cam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
    
        timer = 0.0f;
        waitingTime = 10;
    }


    IEnumerator WaitAndPrint()
    {
        
        farmer.isStopped = true;
        yield return new WaitForSeconds(10);
        farmer.isStopped = false;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {   
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit))
            {
                if(true == hit.transform.gameObject.Equals(gameObject))//내가 클릭됐니?
                {
                    
                    //Debug.Log(hit.transform.gameObject);
                    
                    Vector3 pos = cam.ViewportToWorldPoint(new Vector3 (1, 1, cam.nearClipPlane));
                    transform.LookAt(pos);

                    StartCoroutine(WaitAndPrint());
                    
                }
                
            }
            
        }

    
    }
}