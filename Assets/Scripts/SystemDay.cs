using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SystemDay : MonoBehaviour
{
    public TextMeshProUGUI dateText;
    // Start is called before the first frame update
    void Awake()
    {
        string day = System.DateTime.Now.ToString("d");

        dateText.text = string.Format(day);
    }

    // Update is called once per frame
    void Update()
    {
        string day = System.DateTime.Now.ToString("d");
        
        dateText.text = string.Format(day);
    }
}
