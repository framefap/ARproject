using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOnOff : MonoBehaviour
{
    public GameObject Button;
    // Start is called before the first frame update

    public void TurnButton()
    {
        bool isActive = Button.activeSelf;
        Button.SetActive(!isActive);
     
    }
    
}
