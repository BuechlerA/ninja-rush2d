using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text timerText;
    private float startTime;

    public bool isFinished;

    private void Start()
    {
        timerText = GetComponentInChildren<Text>();
        startTime = Time.time;
    }

    private void Update()
    {
        if (isFinished)
        {
            return;
        }
        else
        {
            float t = Time.time - startTime;
            string minutes = ((int)t / 60f).ToString();
            string seconds = (t % 60).ToString("f2");

            timerText.text = seconds;
        }
    }

    public string GetTimerTime()
    {
        string timerString;
        timerString = timerText.text;
        return timerString;
    }
}
