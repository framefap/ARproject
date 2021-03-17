using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{

    Button button;

    public Sprite NormalIcon;
    public Sprite SelectedIcon;
    void Start()
    {
        button = GetComponent<Button>();
        
        
    }

    // Update is called once per frame
    public void ToggleButtonState()
    {
        if (button.GetComponent<Image>().sprite == NormalIcon)
        {
            button.GetComponent<Image>().sprite = SelectedIcon;
        }

        else if (button.GetComponent<Image>().sprite == SelectedIcon)
        {

            button.GetComponent<Image>().sprite = NormalIcon;

        }
    }
}
