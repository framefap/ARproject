using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeleteButtonManager : MonoBehaviour
{
    public List<Button> DelButtonlist = new List<Button>();

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

    private void AddButtonToList(Button button, bool isSelected)
    {
        SpriteState spriteState = new SpriteState();
        spriteState = button.spriteState;

        if (isSelected) //กดเพื่อselect ปุ่ม
        {
            DelButtonlist.Add(button);

            button.GetComponent<Image>().sprite = SelectedIcon;
            spriteState.highlightedSprite = null;

            Debug.Log(DelButtonlist.Count);
        }
        else //กดเพื่อ deselect ปุ่ม
        {
            DelButtonlist.Remove(button);
            button.GetComponent<Image>().sprite = NormalIcon;
            spriteState.highlightedSprite = HightlightedIcon;

            button.transform.GetChild(0).gameObject.SetActive(false);
            Debug.Log(DelButtonlist.Count);
        }

        button.spriteState = spriteState;
    }

    public void ClearList()
    {
        for (int i = 0; i < DelButtonlist.Count; i++)
        {
            DelButtonlist[i].GetComponent<Image>().sprite = NormalIcon;

        }
        DelButtonlist.Clear();
        Debug.Log(DelButtonlist.Count);
    }

    void Update()
    {
        SelectedText.text = "Delete " + DelButtonlist.Count.ToString() + " file(s) from this folder ?" ;
    }
}
