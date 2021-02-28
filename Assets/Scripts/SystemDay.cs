using System.Collections;
using System.Collections.Generic;
<<<<<<< Updated upstream
=======
using System.Globalization;
>>>>>>> Stashed changes
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SystemDay : MonoBehaviour
{
<<<<<<< Updated upstream
=======
    CultureInfo ci = new CultureInfo("en-US");
>>>>>>> Stashed changes
    public TextMeshProUGUI dateText;
    // Start is called before the first frame update
    void Awake()
    {
<<<<<<< Updated upstream
        string day = System.DateTime.Now.ToString("d");
=======
        string day = System.DateTime.Now.ToString("ddd , dd MMM yy",ci);
>>>>>>> Stashed changes

        dateText.text = string.Format(day);
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        string day = System.DateTime.Now.ToString("d");
=======
        string day = System.DateTime.Now.ToString("ddd , dd MMM yy", ci);
>>>>>>> Stashed changes
        
        dateText.text = string.Format(day);
    }
}
