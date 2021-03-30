using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject gameObject;

   public void DestroyObj()
    {
        Destroy(gameObject);
    }
}
