using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedButtonHandler : MonoBehaviour
{

    public List<Button> selectedButtonlist = new List<Button>();

    private static SelectedButtonHandler instance;

    public static SelectedButtonHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SelectedButtonHandler>();
            }
            return instance;
        }
    }




}
