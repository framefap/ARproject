using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFKReset : MonoBehaviour
{
    // Start is called before the first frame update
    public AFKCheck Afk;
    public void TimeReset()
    {
        Afk.StartTimer();
    }
}
