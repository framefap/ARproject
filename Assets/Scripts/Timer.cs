using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
using System.Globalization;
using TMPro;
>>>>>>> Stashed changes
=======
using System.Globalization;
using TMPro;
>>>>>>> Stashed changes
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeCounter = 0;
    public bool timerIsRunning = false;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    public Text timeText;
=======
    public TextMeshProUGUI timeText;
>>>>>>> Stashed changes
=======
    public TextMeshProUGUI timeText;
>>>>>>> Stashed changes
    public Button RecordButton;
    
  
    public void TimerStartStop()
    {

        timerIsRunning = !timerIsRunning ;
        //Time.timeScale = 200;
        RecordButton.interactable = false;

    }
   
    public void TimerEnd()
    {

        timerIsRunning = false;
        float RecordTime = timeCounter;
        timeCounter = 0;
        Debug.Log(RecordTime);
        RecordButton.interactable = true;

    }

    void Update()
    {
        if (timerIsRunning)
        {
             
            timeCounter += Time.deltaTime;
            DisplayTime(timeCounter);
            
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float hours   = Mathf.FloorToInt(timeToDisplay / 3600);
        float minutes = Mathf.FloorToInt((timeToDisplay / 60)% 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}:{2:00}" , hours, minutes, seconds);
    }
}