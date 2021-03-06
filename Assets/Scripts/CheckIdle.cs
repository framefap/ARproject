using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckIdle : MonoBehaviour
{
    
    int time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        if (!Input.GetKeyDown(KeyCode.Mouse0))
        {
            time += 1;

        }
        else
        {
            time = 0;
        }

        if (time == 100)
        {
            Debug.Log("100 frames passed with no input");

            //Now you could set time too zero so this happens every 100 frames
            time = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
