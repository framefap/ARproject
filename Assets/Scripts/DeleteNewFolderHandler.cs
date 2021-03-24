using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteNewFolderHandler : MonoBehaviour
{

    public Sprite NormalIcon;

    public void ClearList()
    {
        for (int i = 0; i < SelectedButtonHandler.Instance.selectedButtonlist.Count; i++)
        {
            SelectedButtonHandler.Instance.selectedButtonlist[i].GetComponent<Image>().sprite = NormalIcon;

        }
        SelectedButtonHandler.Instance.selectedButtonlist.Clear();
        Debug.Log(SelectedButtonHandler.Instance.selectedButtonlist.Count);
    }

    public void DeleteItem()
    {
        for (int i = 0; i < SelectedButtonHandler.Instance.selectedButtonlist.Count; i++)
        {

            //ลบNewFolderหน้าหลัก
            NewFolderGlobal.NewFolderlist.Remove(SelectedButtonHandler.Instance.selectedButtonlist[i].transform.parent.gameObject);
            Destroy(SelectedButtonHandler.Instance.selectedButtonlist[i].transform.parent.gameObject);

            //ลบNewFolderPanelหน้าหลัก
            string newFolderPanelName = SelectedButtonHandler.Instance.selectedButtonlist[i].transform.parent.gameObject.name + "Panel";
            GameObject newFolderPanel = FindInactiveGameobject.FindInActiveObjectByName(newFolderPanelName);
            NewFolderGlobal.NewFolderPanellist.Remove(newFolderPanel);
            Destroy(newFolderPanel);

            //ลบNewFolderหน้าAddtoFolderPanel
            string addToFolderName = SelectedButtonHandler.Instance.selectedButtonlist[i].transform.parent.gameObject.name;
            GameObject addToFolder = FindInactiveGameobject.FindInActiveObjectByName(addToFolderName);
            Destroy(addToFolder);


            //SelectedButtonHandler.Instance.selectedButtonlist[i].transform.parent.gameObject.SetActive(false);


            //SelectedButtonHandler.Instance.selectedButtonlist.Clear();

        }

        ClearList();
    }
}
