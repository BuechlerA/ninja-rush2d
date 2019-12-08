using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    
    private Text scoreText;

    void Start()
    {
        scoreText = GetComponentInChildren<Text>();
    }

    [ContextMenu("AddScore")]
    public void SetScoreText(int score)
    {
        
        if (score.ToString().Length < 2)
        {
            scoreText.text = "0" + score.ToString();
        }
        else
        {
            scoreText.text = score.ToString();
        }
        
    }
}
