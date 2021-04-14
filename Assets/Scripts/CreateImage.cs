using SC.XR.Unity.Module_InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CreateImage : MonoBehaviour
{
    public GameObject filebutton;
    public SpriteRenderer image;
    public BoundingBox rb;
    private DestroyObject dest;
    private Vector3 Relative;
    private Quaternion Rotation;
    public GameObject insert;

    public string canvasName;

    //public Canvas MyCanvas;


    // Start is called before the first frame update
    public void creation()
    {

        GameObject Closebutton = Resources.Load("close button") as GameObject;
        //GameObject Prefabs = Resources.Load("insert") as GameObject;
        GameObject canvas2 = GameObject.Find(canvasName);
        GameObject sphere = GameObject.Find("Sphere");
        sphere.SetActive(true);

        Relative = sphere.transform.position;
        
        Rotation = sphere.transform.rotation;
        Debug.Log(Relative);
        //sphere.SetActive(false);
     
        //Create your Image GameObject
        // GameObject newObject = new GameObject("FloatingImage");


        //Make the GameObject child of the Canvas
        /* newObject.transform.SetParent(canvas2.transform);
         newObject.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
         //Get Sprite
         newObject.AddComponent<SpriteRenderer>();



         //Center Image to screen
         newObject.GetComponent<Transform>().position = Vector2.zero;

         //newObject.AddComponent<TrackMouse>();

         newObject.transform.localPosition = new Vector3(0, 0, 2.5f);


         image = newObject.GetComponent<SpriteRenderer>();
         image.sprite = filebutton.transform.GetChild(1).GetComponent<Image>().sprite; 
         rb = newObject.AddComponent<BoundingBox>();
         newObject.AddComponent<BoxCollider>();  

         rb.ActiveHandle = BoundingBox.HandleType.Scale;
         rb.ActiveHandle |= BoundingBox.HandleType.Rotation;
         rb.FlattenAxis = BoundingBox.FlattenModeType.FlattenZ; */

        GameObject Picture = Instantiate(insert);
        //GameObject CB = Instantiate(Closebutton, transform.position,transform.rotation);


        Picture.transform.localPosition = Relative;
        Picture.transform.localRotation = Rotation;

        Picture.SetActive(true);
        
        /*CB.transform.SetParent(Picture.transform);
        CB.transform.localPosition = new Vector3(5, 2.5f, 1);
        CB.transform.localScale = new Vector3(20, 20, 20);
        dest = CB.GetComponent<DestroyObject>();*/
        //dest.gameObject = Picture;

       



    }
    
}
