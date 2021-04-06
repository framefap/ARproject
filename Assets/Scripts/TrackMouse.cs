using SC.XR.Unity.Module_InputSystem.InputDeviceHand;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TrackMouse : MonoBehaviour
{
    bool IsRelease;
    Vector3 Onclick;

    // Start is called before the first frame update
    void Start()
    {
        bool IsRelease = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRelease == false)
        {
            Vector3 MousePos = Input.mousePosition;
            Vector3 ObjectPos = Camera.main.WorldToScreenPoint(transform.position);
            MousePos.x = MousePos.x - ObjectPos.x;
            MousePos.y = MousePos.y - ObjectPos.y;
            MousePos.z = MousePos.z - ObjectPos.z;

            transform.position = Vector3.MoveTowards(transform.position, MousePos, 5000 * Time.deltaTime);

            if (Input.GetMouseButtonDown(0))
            {
                transform.position = Vector3.MoveTowards(transform.position, MousePos, 5000 * Time.deltaTime);
                IsRelease = true;
            }
        }
        
    }
}
