using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeCounter = 0;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    public Button RecordButton;

    public Sprite NormalIcon;
    public Sprite DisableIcon;
    
  
    public void TimerStartStop()
    {

        timerIsRunning = !timerIsRunning ;
        //Time.timeScale = 200;
        RecordButton.interactable = false;
        RecordButton.GetComponent<Image>().sprite = DisableIcon;

    }
   
    public void TimerEnd()
    {

        timerIsRunning = false;
        float RecordTime = timeCounter;
        timeCounter = 0;
        Debug.Log(RecordTime);
    
        RecordButton.interactable = true;
        RecordButton.GetComponent<Image>().sprite = NormalIcon;

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