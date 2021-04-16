using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTracking : MonoBehaviour
{

    public bool Isdrawing;
    public GameObject CursorFocus;
    public GameObject CursorHead;

    // Start is called before the first frame update
    void Start()
    {
        Isdrawing = false;
        
    }

    void Update()
    {
        if (!CursorFocus.activeSelf && !CursorHead.activeSelf)
        {
            Isdrawing = true;

        }
        else if (CursorFocus.activeSelf || CursorHead.activeSelf)
        {
            Isdrawing = false;
        }


        if (Isdrawing==false)
        {
            GameObject Tracker = GameObject.Find("DrawTracker");
            GameObject Drawer = GameObject.Find("DrawingReticle");
            Drawer.transform.position = Tracker.transform.position;
            Drawer.transform.rotation = Tracker.transform.rotation;
            
        }

        else if (Isdrawing==true)
        {
            GameObject Tracker = GameObject.Find("DrawTracker");
            GameObject Drawer = GameObject.Find("DrawingReticle");
            Tracker.transform.position = Drawer.transform.position;
            
        }


        

    }
    public void PressTrueFalse()
    {
        if (Isdrawing == false)
        {
            Isdrawing = true;
            Debug.Log(Isdrawing);
        }
        
        else if (Isdrawing == true)
        {
            Isdrawing = false;
            Debug.Log(Isdrawing);
                
        }
    }
    
}