using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ThisOtherThing.UI.Shapes;
using ThisOtherThing.UI.ShapeUtils;

public class ColorPicker : MonoBehaviour
{

    public Ellipse ColorButton;

    public void pickColor()
    {
        Debug.Log(ColorButton.ShapeProperties.FillColor);
        Color32 SelectedColor = gameObject.GetComponent<Ellipse>().ShapeProperties.FillColor;
        Debug.Log(SelectedColor);


        ColorButton.ShapeProperties.FillColor = SelectedColor;
        ColorButton.color = SelectedColor;
        Debug.Log(ColorButton.ShapeProperties.FillColor);


        /*ColorBlock colorButton = ColorButton.colors;
        colorButton.normalColor = SelectedColor;
        ColorButton.colors = colorButton;*/

    }
}
