using System.Collections;
using System.Collections.Generic;
using ThisOtherThing.UI.Shapes;
using UnityEngine;
using UnityEngine.UI;

public class ColorPallete : MonoBehaviour
{
    public LineSettings linesettings;


    // Start is called before the first frame update
    public void ChangeLineColor()
    {
        //Color colorPallete = GetComponent<Image>().color;

        Color colorPallete = GetComponent<Ellipse>().ShapeProperties.FillColor;
        //Debug.Log(colorPallete);

        linesettings.startColor = colorPallete;
        linesettings.endColor = colorPallete;
    }
}
