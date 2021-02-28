using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SystemDay : MonoBehaviour
{
    CultureInfo ci = new CultureInfo("en-US");
    public TextMeshProUGUI dateText;
    // Start is called before the first frame update
    void Awake()
    {
        string day = System.DateTime.Now.ToString("ddd , dd MMM yy",ci);

        dateText.text = string.Format(day);
    }

    // Update is called once per frame
    void Update()
    {
        string day = System.DateTime.Now.ToString("ddd , dd MMM yy", ci);
        
        dateText.text = string.Format(day);
    }
}
