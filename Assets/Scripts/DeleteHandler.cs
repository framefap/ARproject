using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeleteHandler : MonoBehaviour
{

    public Sprite NormalIcon;

    public TextMeshProUGUI SelectedText;
    public void ClearList()
    {
        for (int i = 0; i < SelectedButtonHandler.Instance.selectedButtonlist.Count; i++)
        {
            SelectedButtonHandler.Instance.selectedButtonlist[i].GetComponent<Image>().sprite = NormalIcon;

        }
        SelectedButtonHandler.Instance.selectedButtonlist.Clear();
        Debug.Log(SelectedButtonHandler.Instance.selectedButtonlist.Count);
    }

    public void DeleteItem()
    {
        for (int i = 0; i < SelectedButtonHandler.Instance.selectedButtonlist.Count; i++)
        {
            SelectedButtonHandler.Instance.selectedButtonlist[i].transform.parent.gameObject.SetActive(false);

        }

        ClearList();
    }

    void Update()
    {
        SelectedText.text = "Delete " + SelectedButtonHandler.Instance.selectedButtonlist.Count.ToString() + " file(s) from this folder ?";
    }
}
