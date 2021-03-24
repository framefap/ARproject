using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewFolderManager : MonoBehaviour
{
    public GameObject rootNewFolder;
    public Transform parent;

    public GameObject rootNewFolderPanel;
    public Transform parent1;

    int count = 1;

    public GameObject rootAddtoFolder;
    public Transform parent2;
    int count2 = 1;


    public void NewFolder()
    {
        int countNewFolder = NewFolderGlobal.NewFolderlist.Count;

        if (countNewFolder > 2)
        {
            return;
        }

        //NewFolder
        GameObject NewFolder = Instantiate(rootNewFolder, parent);
        NewFolder.SetActive(true);
       
        NewFolderGlobal.NewFolderlist.Add(NewFolder);

        countNewFolder = NewFolderGlobal.NewFolderlist.Count;
        NewFolder.name = "NewFolder" + countNewFolder.ToString();
        Debug.Log("countNewFolder: " + countNewFolder);

        NewFolder.GetComponentInChildren<TextMeshProUGUI>().text = "NewFolder" + countNewFolder.ToString();


        //NewFolderPanel
        GameObject NewFolderPanel = Instantiate(rootNewFolderPanel, parent1);
        NewFolderGlobal.NewFolderPanellist.Add(NewFolderPanel);

        NewFolderPanel.name = "NewFolder"+ countNewFolder.ToString()+"Panel" ;


        //AddtoFolder
        GameObject AddtoFolder = Instantiate(rootAddtoFolder, parent2);
        AddtoFolder.SetActive(true);

        AddtoFolder.name = "NewFolder" + countNewFolder.ToString();

        AddtoFolder.GetComponentInChildren<TextMeshProUGUI>().text = "NewFolder" + countNewFolder.ToString();

        /*NewFolder.name = "NewFolder"+count.ToString();

        NewFolder.GetComponentInChildren<TextMeshProUGUI>().text = "NewFolder" + count.ToString();

        GameObject NewFolderPanel = Instantiate(rootNewFolderPanel, parent1);
        NewFolderPanel.name = "NewFolder"+ count.ToString()+"Panel" ;

        count++;*/

    }

    public void NewFolder2()
    {
        if (count2 > 3)
        {
            return;
        }

        GameObject AddtoFolder = Instantiate(rootAddtoFolder, parent2);
        AddtoFolder.SetActive(true);
        AddtoFolder.name = "NewFolder" + count2.ToString();


        AddtoFolder.GetComponentInChildren<TextMeshProUGUI>().text = "NewFolder" + count2.ToString();
        count2++;

    }

}
