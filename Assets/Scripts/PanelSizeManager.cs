using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSizeManager : MonoBehaviour
{

    public GameObject sizeablePanel;


    public int sizeincrement = 140;

    RectTransform panelRect;
    Vector2 newsize;
    Vector2 originalsize;

    public int itemlimit;

    void Start()
    {
        panelRect = sizeablePanel.GetComponent<RectTransform>();

        originalsize = new Vector2(panelRect.rect.width, panelRect.rect.height);
        newsize = new Vector2(panelRect.rect.width, panelRect.rect.height + sizeincrement);

    }
    void Update()
    {
        int count = 0;
        foreach(Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                count++;
            }
        }


        if (count > itemlimit)
        {
            LeanTween.size(sizeablePanel.GetComponent<RectTransform>(), newsize, 0.15f).setEase(LeanTweenType.easeOutQuad);
        }

       else
       {
            LeanTween.size(sizeablePanel.GetComponent<RectTransform>(), originalsize, 0.15f).setEase(LeanTweenType.easeOutQuad);
       }
    }
}
