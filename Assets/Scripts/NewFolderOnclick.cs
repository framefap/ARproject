using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewFolderOnclick : MonoBehaviour
{

    
    GameObject NewFolderPanel;
    
    public void SetOnclickNewFolderPanel()
    {
        
        string thisNewFolderName = gameObject.name;
        
        NewFolderPanel = FindInactiveGameobject.FindInActiveObjectByName(thisNewFolderName+"Panel");
        NewFolderPanel.SetActive(true);

    }

    public void SetOnclickAddtoFolder()
    {

        string thisNewFolderName = gameObject.name;

        NewFolderPanel = FindInactiveGameobject.FindInActiveObjectByName(thisNewFolderName + "Panel");

        


        for (int i = 0; i < SelectedButtonHandler.Instance.selectedButtonlist.Count; i++)
        {
            GameObject rootObj = SelectedButtonHandler.Instance.selectedButtonlist[i].transform.parent.gameObject;
            Transform parent = NewFolderPanel.transform;

            if (parent.GetChild(0).childCount >= 4) //เพิ่มไฟล์ในNewFolderได้ไม่เกิน 4 ไฟล์
            {
                Debug.Log("NO more");
                break;
                return;
            }

            GameObject cloneObj = Instantiate(rootObj, parent.GetChild(0));

            Sprite NormalIcon = cloneObj.transform.GetChild(2).gameObject.GetComponent<SelectedButtonManager>().NormalIcon;
            cloneObj.transform.GetChild(2).gameObject.GetComponent<Image>().sprite = NormalIcon; // ทำellipseให้มาปกติแบบยังไม่กดเลือก

            cloneObj.transform.GetChild(2).gameObject.SetActive(false); // ทำให้ ellipse หาย

        }

        //SelectedButtonHandler.Instance.selectedButtonlist.Clear();

        //NewFolderPanel.transform.GetChild(0).gameObject.SetActive(true); //capture image
        NewFolderPanel.transform.GetChild(2).gameObject.SetActive(true); // select button

    }
}
