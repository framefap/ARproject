using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractableManager : MonoBehaviour
{
    Button button;
    public bool btnInteractable;

    bool isSelected = false;


    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        button.interactable = SelectedButtonHandler.Instance.selectedButtonlist.Count >0;
    }

    
}
