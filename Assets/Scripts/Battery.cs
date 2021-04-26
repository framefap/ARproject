using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI BatteryText;
    public GameObject BatteryIcon;
    public Sprite B100;
    public Sprite B75;
    public Sprite B50;
    public Sprite B20;
    void Start()
    {
        string battery = System.IO.File.ReadAllText("/sys/class/power_supply/battery/capacity");
        BatteryText.text = string.Format(battery+"%");
        
        if (int.Parse(battery) > 84)
        {
            BatteryIcon.GetComponent<Image>().sprite = B100;
            
        }
        else if (int.Parse(battery) > 59 & int.Parse(battery) < 85)
        {
            BatteryIcon.GetComponent<Image>().sprite = B75;

        }
        else if (int.Parse(battery) > 35 & int.Parse(battery) < 60)
        {
            BatteryIcon.GetComponent<Image>().sprite = B50;

        }
        else if (int.Parse(battery) > 0 & int.Parse(battery) < 36)
        {
            BatteryIcon.GetComponent<Image>().sprite = B20;

        }

    }

    // Update is called once per frame
    void Update()
    {
        string battery = System.IO.File.ReadAllText("/sys/class/power_supply/battery/capacity");
        int BattText = int.Parse(battery);
        BatteryText.text = string.Format(BattText.ToString()+"%");
        if (int.Parse(battery) > 84)
        {
            BatteryIcon.GetComponent<Image>().sprite = B100;

        }
        else if (int.Parse(battery) > 59 & int.Parse(battery) < 85)
        {
            BatteryIcon.GetComponent<Image>().sprite = B75;

        }
        else if (int.Parse(battery) > 35 & int.Parse(battery) < 60)
        {
            BatteryIcon.GetComponent<Image>().sprite = B50;

        }
        else if (int.Parse(battery) > 0 & int.Parse(battery) < 36)
        {
            BatteryIcon.GetComponent<Image>().sprite = B20;

        }

    }
}
