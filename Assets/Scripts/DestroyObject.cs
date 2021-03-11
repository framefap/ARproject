using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DestroyObject : MonoBehaviour, IPointerClickHandler
{

    
    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }



    // Update is called once per frame
    void Update()
    {
        GameObject ClickListenerPanel = GameObject.Find("ClickListenerPanel");

        ClickListenerPanel.SetActive(true);



        if (Input.GetKeyDown(KeyCode.Mouse0)) //ถ้ามีการคลิกซ้ายที่หน้าจอ
        {
            gameObject.GetComponent<FadeOut>().fadeOut();
        }
        else //ถ้าไม่มีการคลิกซ้าย ให้delay แล้วfadeout
        {
            StartCoroutine(Hide());
        }

        IEnumerator Hide()
        {
            yield return new WaitForSeconds(5);
            gameObject.GetComponent<FadeOut>().fadeOut();
        }
    }
}
