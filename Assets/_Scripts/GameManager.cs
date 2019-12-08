using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GUIManager guiManager;
    public GameStates gameStates;

    public int gameScore;

    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        guiManager = GetComponent<GUIManager>();

        gameScore = 0;
    }

    public void AddScore()
    {
        gameScore++;
        GameObject.Find("ScorePanel").GetComponent<ScorePanel>().SetScoreText(gameScore);
    }

    public void SetState(GameStates state)
    {
        switch (state)
        {
            case GameStates.menu:
                gameStates = GameStates.menu;
                break;
            case GameStates.play:
                gameStates = GameStates.play;
                break;
            case GameStates.dead:
                gameStates = GameStates.dead;
                guiManager.GameOver();
                break;
            default:
                break;
        }
    }
}
