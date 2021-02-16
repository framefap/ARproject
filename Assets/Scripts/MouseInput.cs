using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseInput : MonoBehaviour
{

    public GameObject Panel;
    public GameObject CurrentPanel;
    public Animator Fadein;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            bool isActive = Panel.activeSelf;
            bool isNewActive = CurrentPanel.activeSelf;

            Panel.SetActive(!isActive);
            CurrentPanel.SetActive(!isNewActive);

            UnlockScreen();

            //testGitHUB 001
        }
    }
    public void UnlockScreen()
    {
        Fadein.SetTrigger("UnlockScreen");
    }
}
