using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewAddtoFolderManager : MonoBehaviour
{
    public GameObject rootObj; //capture image
    Transform parent;// newfolderxx panel

    int count = 1;

    public void NewFolder()
    {
        parent = transform.Find("NewFolder" + count.ToString() + "Panel");
        
        if (count > 3)
        {
            return;
        }

        GameObject FilePanel = Instantiate(rootObj, parent);
        FilePanel.SetActive(true);
        FilePanel.name = "FileButton" + (count + 3).ToString();


        FilePanel.GetComponentInChildren<TextMeshProUGUI>().text = "NewFolder" + count.ToString();
        count++;

    }
}
