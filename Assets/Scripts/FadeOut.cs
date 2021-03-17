using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FadeOut : MonoBehaviour
{

    private LTDescr _tweenObject;
    public float FadeAnimationDuration = 0.3f;

    public void fadeOut()
    {
        if (gameObject.GetComponent<CanvasGroup>() == null)
        {
            gameObject.AddComponent<CanvasGroup>();
        }
        
        _tweenObject = LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 0, FadeAnimationDuration);
        StartCoroutine(Hide());
        
    }
    IEnumerator Hide()
    {
        yield return new WaitForSeconds(FadeAnimationDuration);
        gameObject.SetActive(false);
    }

}
