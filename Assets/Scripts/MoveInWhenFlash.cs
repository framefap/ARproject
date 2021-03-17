using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveInWhenFlash : MonoBehaviour
{
    public Animator Flashscreen;
    public GameObject ScreenshotPanel;
    float animationDuration;

    void Update()
    {
        if (Flashscreen.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.4)
        {  //If normalizedTime is 0 to 1 means animation is playing, if greater than 1 means finished

            //do something
            //Debug.Log("Has flash");
            gameObject.GetComponent<UITweener>().enabled = true;

            StartCoroutine(Hide());
        }

        IEnumerator Hide()
        {
            yield return new WaitForSeconds(3);
            gameObject.GetComponent<FadeOut>().fadeOut();
        }


    }

    public void StopCoroutine()
    {
        StopAllCoroutines();
    }


}
