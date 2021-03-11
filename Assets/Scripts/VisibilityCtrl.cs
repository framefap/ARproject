using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibilityCtrl : MonoBehaviour
{
    [SerializeField] bool shouldStartVisible;

    GameObject _myGameObj;
    GameObject _invisibleBG;

    void Awake()
    {
        setupInvisibleBG();
        _myGameObj = gameObject;

        if (!shouldStartVisible)
            hide();
    }

    void setupInvisibleBG()
    {
        _invisibleBG = new GameObject("InvisibleBG");

        InvisibleBGCtrl tempInvisibleBGCtrl = _invisibleBG.AddComponent<InvisibleBGCtrl>();
        tempInvisibleBGCtrl.setParentCtrl(this);

        Image tempImage = _invisibleBG.AddComponent<Image>();
        tempImage.color = new Color(1f, 1f, 1f, 0f);

        RectTransform tempTransform = _invisibleBG.GetComponent<RectTransform>();
        tempTransform.anchorMin = new Vector2(0f, 0f);
        tempTransform.anchorMax = new Vector2(1f, 1f);
        tempTransform.offsetMin = new Vector2(0f, 0f);
        tempTransform.offsetMax = new Vector2(0f, 0f);
        tempTransform.SetParent(GetComponentsInParent<Transform>()[1], false);
        tempTransform.SetSiblingIndex(transform.GetSiblingIndex()); // put it right beind this panel in the hierarchy
    }

    void OnEnable()
    {
        if (_myGameObj.GetComponent<CanvasGroup>() == null)
        {
            _myGameObj.AddComponent<CanvasGroup>();
        }
        _myGameObj.GetComponent<CanvasGroup>().alpha = 1;

        _invisibleBG.SetActive(true);

        //เริ่มมาให้เริ่มนับเวลา delay fadeoutเลย 
        StartCoroutine(Inactive());
    }

    public void hide()
    {
        _myGameObj.GetComponent<FadeOut>().fadeOut();
        //_myGameObj.SetActive(false);
        _invisibleBG.SetActive(false);
    }

    IEnumerator Inactive()
    {
        yield return new WaitForSeconds(2f); // delay 2 วิแล้วfadeout
        _myGameObj.GetComponent<FadeOut>().fadeOut();
        _invisibleBG.SetActive(false);
    }
}
