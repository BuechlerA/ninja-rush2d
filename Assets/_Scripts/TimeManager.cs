using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float slowTime = 0.08f;
    private float normalTime = 1.0f;

    public bool isTimeSlow;
    private bool isTimeStopped;

    private SlowMoEnergyBehaviour slowMoEnergy;

    private void Start()
    {
        slowMoEnergy = GameObject.Find("Player").GetComponentInChildren<SlowMoEnergyBehaviour>();
    }

    private void Update()
    {
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

    }

    public void DoSlowMo()
    {
        if (slowMoEnergy.slowMoEnergyMagnitude > 0f)
        {
            isTimeSlow = true;
            Time.timeScale = slowTime;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
        else
        {
            return;
        }
    }

    public void UnSlowMo()
    {
        isTimeSlow = false;
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
