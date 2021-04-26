using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFKCheck : MonoBehaviour
{

    public float AFKTimer;
    
    public GameObject Show;
    public GameObject Menu;
    
    // Start is called before the first frame update
    void Start()
    {
        AFKTimer = 0;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
            AFKTimer += 1;
            if (AFKTimer > 7200)
            {
                Debug.Log("hello");
                Show.SetActive(false);//ShowMenuButton เป็น Active แล้ว MenuButton Inactive
                Menu.SetActive(true);
                
                AFKTimer = 0;
            }
        Debug.Log(AFKTimer);
      
    }

    public void StartTimer()
    {
        //Debug.Log(AFKTimer);
        AFKTimer = 0;
        
       // Debug.Log("hello");
    }
}
