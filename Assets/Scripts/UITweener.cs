using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum UIAnimationType
{
    Move,
    Scale
}
public class UITweener : MonoBehaviour
{
    // Start is called before the first frame update
    public UIAnimationType animationType;
    public LeanTweenType easeType;

    public float animationDuration;

    public Vector3 from;
    public Vector3 to;

    private LTDescr _tweenObject;

    public void OnEnable()
    {
        Show();

        /*LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.4f).setEase(easeType);
        LeanTween.moveY(gameObject, 20, 0.4f).setEase(easeType);*/
    }

    public void Show()
    {
        HandleTween();
    }

    public void HandleTween()
    {
        switch (animationType)
        {
            case UIAnimationType.Move:
                MoveAbsolute();
                break;

            case UIAnimationType.Scale:
                Scale();
                break;


        }

        _tweenObject.setEase(easeType);
    }

    public void Scale()
    {
        _tweenObject = LeanTween.scale(gameObject, to, animationDuration);
    }

    public void MoveAbsolute()
    {
        gameObject.GetComponent<RectTransform>().anchoredPosition = from;

        _tweenObject = LeanTween.move(gameObject.GetComponent<RectTransform>(), to, animationDuration);


    }
}

