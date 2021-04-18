using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryIconChanger : MonoBehaviour
{
    //Battery percent text
    string batteryText;
    
    public Image batteryIcon;


    public Sprite battery100;
    public Sprite battery75;
    public Sprite battery50;
    public Sprite battery25;

    
    void Update()
    {
        switch (batteryText)
        {
            case "100":
                batteryIcon.sprite = battery100;
                break;

            case "75":
                batteryIcon.sprite = battery75;
                break;

            case "50":
                batteryIcon.sprite = battery50;
                break;

            case "25":
                batteryIcon.sprite = battery25;
                break;
        }
    }
}
