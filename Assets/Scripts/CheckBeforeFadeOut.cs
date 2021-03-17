using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBeforeFadeOut : MonoBehaviour
{
    public GameObject FileOptionPanel;
    public GameObject SharePanel;
    public GameObject AddtoFolderPanel;

    public GameObject NormalButton;
    public GameObject ActiveButton;


    // Start is called before the first frame update
    public void CheckFade()
    {
        //Debug.Log(CheckBeforeActive.CanbeActive);

        if (!(FileOptionPanel.activeSelf || SharePanel.activeSelf || AddtoFolderPanel.activeSelf))
        {
            ActiveButton.SetActive(false);
            NormalButton.SetActive(true);

            gameObject.GetComponent<FadeOut>().fadeOut();
        }
    }
}
