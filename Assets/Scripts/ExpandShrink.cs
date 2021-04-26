using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandShrink : MonoBehaviour
{
    
    LTDescr _tweenObject;

    public GameObject StopButton;
    float animationDuration = 0.2f;
    Vector2 ExpandSize = new Vector2(760, 140);
    Vector2 ShrinkSize = new Vector2(620, 140);

    public void Expand()
    {
        _tweenObject = LeanTween.size(gameObject.GetComponent<RectTransform>(), ExpandSize, animationDuration);

        StopButton.SetActive(true);
        LeanTween.move(StopButton.GetComponent<RectTransform>(), new Vector3(620, 0, 0), animationDuration);

        //เลื่อน bottompanel ไปซ้าย หลบปุ่มเลือกสี
        LeanTween.move(gameObject.GetComponent<RectTransform>(), new Vector3(-30, 20, 0), animationDuration);

    }

    public void Shrink()
    {
        _tweenObject = LeanTween.size(gameObject.GetComponent<RectTransform>(), ShrinkSize, 0.15f).setEase(LeanTweenType.easeOutQuad);

        LeanTween.move(StopButton.GetComponent<RectTransform>(), new Vector3(480, 0, 0), 0.15f).setEase(LeanTweenType.easeOutQuad);
        StartCoroutine(Hide());

        //เลื่อน bottompanel กลับมาตรงกลาง
        LeanTween.move(gameObject.GetComponent<RectTransform>(), new Vector3(0, 20, 0), animationDuration);
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(0.15f);
        StopButton.SetActive(false);


    }


}
