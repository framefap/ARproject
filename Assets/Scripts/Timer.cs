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
    public Button PausePlayButton;

    public Sprite NormalIcon;
    public Sprite ClickedIcon;

    public GameObject RecordPanel;
    
  
    public void TimerStart()
    {

        //Timer Start
        timerIsRunning = !timerIsRunning ;
        Debug.Log(timerIsRunning);
        //Time.timeScale = 200;
        //RecordButton.interactable = false;
        //RecordButton.GetComponent<Image>().sprite = ClickedIcon;

        //Timer Stop
        if (timerIsRunning == false)
        {
            float RecordTime = timeCounter;
            timeCounter = 0;
            Debug.Log(RecordTime);

            //RecordButton.interactable = true;
            PausePlayButton.GetComponent<Image>().sprite = NormalIcon;
            RecordPanel.SetActive(false);
            GameObject.Find("RecordingFrame").SetActive(false);

        }


    }

    public void TogglePausePlay()
    {

        
        timerIsRunning = !timerIsRunning;
        Debug.Log(timerIsRunning);

        if (timerIsRunning == false) //Timer pause
        {
            PausePlayButton.GetComponent<Image>().sprite = ClickedIcon;

        }
        else //Timer play (Start)
        {
            
            PausePlayButton.GetComponent<Image>().sprite = NormalIcon;

        }
        
    }
   
    public void TimerEnd()
    {
        timerIsRunning = false;
        float RecordTime = timeCounter;
        timeCounter = 0;
        Debug.Log(RecordTime);

        //RecordButton.interactable = true;


    }

    void Update()
    {
        if (timerIsRunning) //Timer Play
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