using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float timeCounter = 0;
    bool timerIsRunning = false;
    public TextMeshProUGUI timeText;
    public Button RecordButton;

    public Sprite NormalIcon;
    public Sprite ClickedIcon;

    public GameObject RecordPanel;
    
  
    public void TimerStartStop()
    {

        //Start Stop ในปุ่มเดียว (ปุ่ม Record Button)

        //Timer Start
        timerIsRunning = !timerIsRunning ;
        //Time.timeScale = 200;
        //RecordButton.interactable = false;
        RecordButton.GetComponent<Image>().sprite = ClickedIcon;

        //Timer Stop
        if (timerIsRunning == false)
        {
            float RecordTime = timeCounter;
            timeCounter = 0;
            Debug.Log(RecordTime);

            //RecordButton.interactable = true;
            RecordButton.GetComponent<Image>().sprite = NormalIcon;
            RecordPanel.SetActive(false);
            GameObject.Find("RecordingFrame").SetActive(false);

        }


    }
   
    public void TimerEnd()
    {
        timerIsRunning = false;
        float RecordTime = timeCounter;
        timeCounter = 0;
        Debug.Log(RecordTime);

        //RecordButton.interactable = true;
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