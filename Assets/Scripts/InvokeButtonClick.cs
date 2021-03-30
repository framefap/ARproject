using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvokeButtonClick : MonoBehaviour
{
    public Button buttonToInvoke;

    public void InvokeBtnClick()
    {
        buttonToInvoke.onClick.Invoke();
    }
}
