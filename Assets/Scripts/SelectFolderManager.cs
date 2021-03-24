using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFolderManager : MonoBehaviour
{
    public GameObject content;

    public int itemlimit = 3;

    public void SetActiveEllipse()
    {
        for (int i = content.transform.childCount; i > itemlimit ; i--)
        {
            
            //Debug.Log(content.transform.GetChild(i-1));
            content.transform.GetChild(i-1).GetChild(2).gameObject.SetActive(true);
        }
    }

    public void InactiveEllipse()
    {
        for (int i = content.transform.childCount; i > itemlimit; i--)
        {

            //Debug.Log(content.transform.GetChild(i-1));
            content.transform.GetChild(i - 1).GetChild(2).gameObject.SetActive(false);
        }
    }
}
