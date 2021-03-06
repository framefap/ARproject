using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureImageScale : MonoBehaviour
{
    float Duration = 2;
    private LTDescr _tweenObject;

    void OnEnable()
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(1920, 1080);
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 1080);

        _tweenObject = LeanTween.size(gameObject.GetComponent<RectTransform>(), new Vector2(392, 233), 0.8f);
        _tweenObject = LeanTween.move(gameObject, new Vector3(20, 251.5f, 0), 0.8f);


        StartCoroutine(Delay());

    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(Duration);
        gameObject.SetActive(false);
    }
}
