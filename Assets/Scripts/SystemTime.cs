using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SystemTime : MonoBehaviour
{
    CultureInfo ci = new CultureInfo("en-US");
    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Awake()
    {
        string time = System.DateTime.Now.ToString("HH:mm", ci);

        timeText.text = string.Format(time);

    }

    // Update is called once per frame
    void Update()
    {
        string time = System.DateTime.Now.ToString("HH:mm", ci);

        timeText.text = string.Format(time);
    }
}
