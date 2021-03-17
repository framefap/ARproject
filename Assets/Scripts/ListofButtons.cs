using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ListofButtons : MonoBehaviour
{
    public List<Button> shareContactlist = new List<Button>();

    public Sprite NormalIcon;
    public Sprite SelectedIcon;
    public Sprite HightlightedIcon;

    public TextMeshProUGUI SelectedText;

    public void BtnClick(Button button)
    {

        bool isSelected = true;

        if (button.GetComponent<Image>().sprite == SelectedIcon)
        {
            isSelected = false;
            //Debug.Log("going to deselect");
        }

        AddButtonToList(button, isSelected);
    }

    public void AddButtonToList(Button button, bool isSelected)
    {

        SpriteState spriteState = new SpriteState();
        spriteState = button.spriteState;

        if (isSelected) //กดเพื่อselect ปุ่ม
        {
            shareContactlist.Add(button);

            button.GetComponent<Image>().sprite = SelectedIcon;
            spriteState.highlightedSprite = null;

            Debug.Log(shareContactlist.Count);
        }
        else //กดเพื่อ deselect ปุ่ม
        {
            shareContactlist.Remove(button);
            button.GetComponent<Image>().sprite = NormalIcon;
            spriteState.highlightedSprite = HightlightedIcon;

            button.transform.GetChild(0).gameObject.SetActive(false);
            Debug.Log(shareContactlist.Count);
        }

        button.spriteState = spriteState;
        //Debug.Log(shareContactlist.Count);

        /*for (int i = 0; i < shareContactlist.Count; i++)
        {
           if (shareContactlist[i].name == button.name)
           {
                shareContactlist[i].GetComponent<Image>().sprite = SelectedIcon;

                shareContactlist[i].transform.GetChild(0).gameObject.SetActive(true);
                shareContactlist[i].GetComponentInChildren<TextMeshProUGUI>().text = (i+1).ToString();
           }
        }*/
    }

    public void ClearList()
    {
        for (int i = 0; i < shareContactlist.Count; i++)
        {
            shareContactlist[i].GetComponent<Image>().sprite = NormalIcon;
            shareContactlist[i].transform.GetChild(0).gameObject.SetActive(false);
            

        }
        shareContactlist.Clear();
        Debug.Log(shareContactlist.Count);
    }

    void Update()
    {
        for (int i = 0; i < shareContactlist.Count; i++)
        {
            shareContactlist[i].transform.GetChild(0).gameObject.SetActive(true);
            shareContactlist[i].GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
            
        }

        SelectedText.text = shareContactlist.Count.ToString() + " Selected";
    }
}
