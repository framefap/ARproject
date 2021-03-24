using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNewFolder : MonoBehaviour
{

    public GameObject content;
    public GameObject selectButton;

    //check ว่าเพิ่ม NewFolder มาสักอันนึงไหม ถ้ามี ปุ่มSelectจะโชว์ขึ้นมา
    void Update()
    {
        int count = 0;
        foreach (Transform child in content.transform)
        {
            if (child.gameObject.activeSelf)
            {
                count++;
            }
        }

        if (count > 3)
        {
            selectButton.SetActive(true);
        }
        else 
        {
            selectButton.SetActive(false);
        }

    }
}
