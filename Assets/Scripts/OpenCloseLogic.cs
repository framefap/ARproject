using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseLogic : MonoBehaviour
{

    //public GameObject thisPanel;

    bool checkFirstTime = true;

    public void openLogic()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Debug.Log(transform.GetChild(i).gameObject.name);

            if (transform.GetChild(i).gameObject.activeInHierarchy) //ถ้ามี 1 panel active อยู่แสดงว่าไม่ได้เปิดครั้งแรก
            {
               
                //thisPanel.SetActive(true);
                checkFirstTime = false;



            }
        }

        if (checkFirstTime) //ถ้าไม่มี panel active อยู่เลย แสดงว่ากดปุ่มครั้งแรก
        {
            Debug.Log(gameObject.transform.GetChild(0).gameObject.name);
            transform.GetChild(0).gameObject.SetActive(true); //เปิด panel แรกในmaster panel
        }



    }
}
  
