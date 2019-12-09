using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel : PanelBehaviour
{

    private Text stoppedTimeText;

    public override void Start()
    {
        base.Start();
        textMessage = GameObject.Find("WinMessage").GetComponent<Text>();
        textMessage.text = messages.winMessages[Random.Range(0, messages.winMessages.Length)];
        stoppedTimeText = GameObject.Find("StoppedTimeText").GetComponent<Text>();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
        stoppedTimeText.text = "Your Time: " + GameObject.Find("TimerPanel").GetComponent<Timer>().GetTimerTime();
    }

}
