using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFKCheck : MonoBehaviour
{

    float AFKTimer;
    bool IsMenuOn;
    public GameObject Show;
    public GameObject Menu;
    
    // Start is called before the first frame update
    void Start()
    {
        IsMenuOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMenuOn == true)
        {
            AFKTimer += 1;
            Debug.Log("SSS");
            if (AFKTimer > 2)
            {
                Debug.Log("hello");
                Show.SetActive(false);//ShowMenuButton เป็น Active แล้ว MenuButton Inactive
                Menu.SetActive(true);
                IsMenuOn = false;
            }
        }
    }

    public void StartTimer()
    {
        AFKTimer = 0;
        IsMenuOn = true;
        Debug.Log("hello");
    }
}
