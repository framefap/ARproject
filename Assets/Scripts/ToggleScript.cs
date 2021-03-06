using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleScript : MonoBehaviour
{
    public GameObject Target;
    // Start is called before the first frame update
    public void Toggle()
    {
        bool isActive = Target.activeSelf;
        Target.SetActive(!isActive);

    }
}
