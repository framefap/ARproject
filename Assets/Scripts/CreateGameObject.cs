using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateGameObject : MonoBehaviour
{

    public Sprite SelectSprite;


    public void Create()
    {
        GameObject go = new GameObject("ARObj");
        go.AddComponent<SpriteRenderer>();
        go.GetComponent<SpriteRenderer>().sprite = SelectSprite;
        go.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);



        
    }
    
}
