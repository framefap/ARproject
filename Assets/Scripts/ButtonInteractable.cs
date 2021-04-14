using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractable : MonoBehaviour
{
    public Transform content;

    public void SetInteractable(bool Isinteractable)
    {
        foreach(Transform child in content)
        {
            child.GetComponent<Button>().interactable = Isinteractable;
        }
    }
}
