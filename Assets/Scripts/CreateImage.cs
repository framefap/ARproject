using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateImage : MonoBehaviour
{
    public GameObject filebutton;
    public Image image;
    
    public Canvas MyCanvas;

    // Start is called before the first frame update
    public void creation()
    {
       
        //Create Canvas
        GameObject canvas = createCanvas(false);

        //Create your Image GameObject
        GameObject newObject = new GameObject("ObjectName");

        //Make the GameObject child of the Canvas
        newObject.transform.SetParent(canvas.transform);

        //Get Sprite
        newObject.AddComponent<Image>();


        //Center Image to screen
        newObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        newObject.AddComponent<TrackMouse>();


        image = newObject.GetComponent<Image>();
        image.sprite = filebutton.transform.GetChild(1).GetComponent<Image>().sprite;
   

       
    }
    private GameObject createCanvas(bool hide)
    {
        //Create Canvas GameObject
        GameObject tempCanvas = new GameObject("Canvas");
        if (hide)
        {
            tempCanvas.hideFlags = HideFlags.HideAndDontSave;
        }

        //Create and Add Canvas Component
        Canvas cnvs = tempCanvas.AddComponent<Canvas>();
        cnvs.renderMode = RenderMode.ScreenSpaceOverlay;
        cnvs.pixelPerfect = false;

        //Set Cavas sorting order to be above other Canvas sorting order
        cnvs.sortingOrder = 12;

        cnvs.targetDisplay = 0;

        addCanvasScaler(tempCanvas);
        addGraphicsRaycaster(tempCanvas);
        MyCanvas = tempCanvas.AddComponent<Canvas>();
        return tempCanvas;
    }

    //Adds CanvasScaler component to the Canvas GameObject 
    private void addCanvasScaler(GameObject parentaCanvas)
    {
        CanvasScaler cvsl = parentaCanvas.AddComponent<CanvasScaler>();
        cvsl.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        cvsl.referenceResolution = new Vector2(800f, 600f);
        cvsl.matchWidthOrHeight = 0.5f;
        cvsl.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        cvsl.referencePixelsPerUnit = 100f;
    }

    //Adds GraphicRaycaster component to the Canvas GameObject 
    private void addGraphicsRaycaster(GameObject parentaCanvas)
    {
        GraphicRaycaster grcter = parentaCanvas.AddComponent<GraphicRaycaster>();
        grcter.ignoreReversedGraphics = true;
        grcter.blockingObjects = GraphicRaycaster.BlockingObjects.None;
    }
}
