using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedButtonHandler : MonoBehaviour
{

    public List<Button> selectedButtonlist = new List<Button>();

    //public List<GameObject> selectedButtonlist = new List<GameObject>();

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
