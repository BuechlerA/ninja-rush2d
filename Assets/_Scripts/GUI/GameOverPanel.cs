using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{

    public float moveAmount;

    private Text gameOverMessage;
    public string[] gameOverStrings;

    private void Start()
    {
        gameOverMessage = GameObject.Find("GameOverMessage").GetComponent<Text>();
    }

    public void OpenPanel()
    {
        gameOverMessage.text = gameOverStrings[Random.Range(0, gameOverStrings.Length)];
        LeanTween.moveX(gameObject, moveAmount, 0.5f).setEaseOutBounce();     
    }

}
