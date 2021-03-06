using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum UIAnimationType
{
    Move,
    Scale,
    FadeOut
}
public class UITweener : MonoBehaviour
{
    public UIAnimationType animationType;
    public LeanTweenType easeType;

    public float animationDuration;

    public Vector3 from;
    public Vector3 to;

    private LTDescr _tweenObject;

    bool checkDisable;
    

    public void OnEnable()
    {
        checkDisable = false;
        Show();

        /*LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.4f).setEase(easeType);
        LeanTween.moveY(gameObject, 20, 0.4f).setEase(easeType);*/
    }

    public void Show()
    {
        if (gameObject.GetComponent<CanvasGroup>() == null)
        {
            gameObject.AddComponent<CanvasGroup>();
        }

        gameObject.GetComponent<CanvasGroup>().alpha = 1;
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

         public void MoveAbsolute()
    {
        if (checkDisable)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = to;
            _tweenObject = LeanTween.move(gameObject.GetComponent<RectTransform>(), from, animationDuration);
            Debug.Log("about to Move");
            
            StartCoroutine(Hide());

        }

        else
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = from;
            _tweenObject = LeanTween.move(gameObject.GetComponent<RectTransform>(), to, animationDuration);
        }

    }

    public void Scale()
    {
        gameObject.GetComponent<RectTransform>().localScale = from;
        _tweenObject = LeanTween.scale(gameObject, to, animationDuration);
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(animationDuration);
        gameObject.SetActive(false);
    }
}

