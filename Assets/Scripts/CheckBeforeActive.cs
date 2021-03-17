using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ThisOtherThing.UI.Shapes;

public class CheckBeforeActive : MonoBehaviour
{

    public GameObject FileOptionPanel;
    public GameObject SharePanel;
    public GameObject AddtoFolderPanel;

    public GameObject gameObjectToActive;

    public static bool CanbeActive=false;

    private static bool Instance
    {
        get { return CanbeActive; }
    }

  

    public void SetActive()
    {
        if (!(FileOptionPanel.activeSelf || SharePanel.activeSelf || AddtoFolderPanel.activeSelf))
        {
            gameObjectToActive.SetActive(true);
        }
        
    }

}
