using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewItemInstantiate : MonoBehaviour
{
    public GameObject rootItem;
    public Transform parentContent;
    public string gameObjectName = "Screenshot";

    public void InstantiateItem()
    {

        if (parentContent.transform.childCount > 4) //กดเพิ่ม screenshot ไปในfolder screenshot ได้มากสุดแค่ 4 รูป
        {
            return;
        }

        GameObject newItem = Instantiate(rootItem, parentContent);
        newItem.SetActive(true);

        newItem.name = gameObjectName;

    }
}
