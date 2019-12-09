using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : PanelBehaviour
{
    public override void Start()
    {
        base.Start();
        textMessage = GameObject.Find("GameOverMessage").GetComponent<Text>();
        textMessage.text = messages.gameOverMessages[Random.Range(0, messages.winMessages.Length)];
    }
}
