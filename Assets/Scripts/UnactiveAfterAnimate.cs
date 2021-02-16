using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnactiveAfterAnimate : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator Flashscreen;
    public GameObject ScreenshotPanel;
    void Update()
    {
        bool isanimated = Flashscreen.isInitialized;

        if (Flashscreen.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {  //If normalizedTime is 0 to 1 means animation is playing, if greater than 1 means finished
            ScreenshotPanel.SetActive(false);
        }

    }
}
