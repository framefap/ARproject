using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedButtonManager : MonoBehaviour
{
    Button button;

    public Sprite NormalIcon;
    public Sprite SelectedIcon;
    public Sprite HightlightedIcon;


    void Awake()
    {
        button = GetComponent<Button>();
    
    }

    public void BtnClicked()
    {
        SpriteState spriteState = new SpriteState();
        spriteState = button.spriteState;

        if (button.GetComponent<Image>().sprite == NormalIcon)
        {

            SelectedButtonHandler.Instance.selectedButtonlist.Add(button);
            Debug.Log(SelectedButtonHandler.Instance.selectedButtonlist.Count);

            button.GetComponent<Image>().sprite = SelectedIcon;
            //spriteState.highlightedSprite = null;

        }
        else if (button.GetComponent<Image>().sprite == SelectedIcon)
        {

            SelectedButtonHandler.Instance.selectedButtonlist.Remove(button);
            Debug.Log(SelectedButtonHandler.Instance.selectedButtonlist.Count);

            button.GetComponent<Image>().sprite = NormalIcon;
            //spriteState.highlightedSprite = HightlightedIcon;

        }

        button.spriteState = spriteState;

    }
}
