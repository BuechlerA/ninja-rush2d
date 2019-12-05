using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float slowTime = 0.08f;
    private float normalTime = 1.0f;

    private bool isTimeStopped;

    private void Update()
    {
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        
    }

    public void DoSlowMo()
    {
        Time.timeScale = slowTime;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    public void UnSlowMo()
    {
        Time.timeScale = normalTime;
    }

    public void StopTime()
    {
        if (isTimeStopped)
        {
            Time.timeScale = normalTime;
            isTimeStopped = false;
        }
        else
        {
            Time.timeScale = 0f;
            isTimeStopped = true;
        }
    }
}
