using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VectorGraphics;

public class ButtonState : MonoBehaviour
{

    public Button thisButton;
    public Sprite normalSprite;
    public Sprite clickedSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        GetComponent<SVGImage>().sprite = clickedSprite;
    }

    public void OnMouseExit()
    {
        GetComponent<SVGImage>().sprite = normalSprite;
    }
}
