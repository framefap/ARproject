using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvisibleBGCtrl : MonoBehaviour, IPointerClickHandler
{
    VisibilityCtrl _parentCtrl;

    public void setParentCtrl(VisibilityCtrl ctrl)
    {
        _parentCtrl = ctrl;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _parentCtrl.hide();
    }
}
