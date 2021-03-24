using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallDelay : MonoBehaviour
{
    public float delayTime = 2;

    public Button CallingPanel;
    

    public void StartCalling()
    {

        StartCoroutine(Delay());
        //CallingPanel.onClick.Invoke();


    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime);
        CallingPanel.onClick.Invoke();
    }

}
