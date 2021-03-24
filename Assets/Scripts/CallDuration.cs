using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CallDuration : MonoBehaviour
{
    float timeCounter = 0;
    bool timerIsRunning = false;

    public TextMeshProUGUI timeText;
    public Button PlayButton;
    public Button StopButton;

    

    public void TimerStart()
    {

        //Timer Start
        timerIsRunning = !timerIsRunning;

        //Time.timeScale = 200;
        //RecordButton.interactable = false;
        //RecordButton.GetComponent<Image>().sprite = ClickedIcon;

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

        float hours = Mathf.FloorToInt(timeToDisplay / 3600);
        float minutes = Mathf.FloorToInt((timeToDisplay / 60) % 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}
