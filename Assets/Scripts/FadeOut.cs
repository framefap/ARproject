using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    private LTDescr _tweenObject;
    public float Fadetime = 0.3f;


    public void fadeOut()
    {
        if (gameObject.GetComponent<CanvasGroup>() == null)
        {
            gameObject.AddComponent<CanvasGroup>();
        }

        _tweenObject = LeanTween.alphaCanvas(gameObject.GetComponent<CanvasGroup>(), 0, Fadetime);
        StartCoroutine(Hide());
    }
    IEnumerator Hide()
    {
        yield return new WaitForSeconds(Fadetime);
        gameObject.SetActive(false);
    }

}
