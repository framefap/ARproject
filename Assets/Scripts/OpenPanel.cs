using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    public GameObject Panel;
    public GameObject CurrentPanel;
    
    public void PanelActive()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            bool isNewActive = CurrentPanel.activeSelf;
            Panel.SetActive(!isActive);
            CurrentPanel.SetActive(!isNewActive);
            

        }

        //Input.GetKeyDown(KeyCode.Mouse0)
    }
}
