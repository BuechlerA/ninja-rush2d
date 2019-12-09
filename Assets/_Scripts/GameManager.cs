using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GUIManager guiManager;
    public GameStates gameStates;

    public int gameScore;

    public int enemyCount;

    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        guiManager = GetComponent<GUIManager>();

        gameScore = 0;

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    private void Update()
    {
        if (gameScore == enemyCount && gameStates == GameStates.play)
        {
            LevelWin();
        }
    }

    public void AddScore()
    {
        gameScore++;
        GameObject.Find("ScorePanel").GetComponent<ScorePanel>().SetScoreText(gameScore);
    }

    public void LevelWin()
    {
        SetState(GameStates.menu);
        GameObject.Find("TimerPanel").GetComponent<Timer>().isFinished = true;
        GameObject.Find("WinPanel").GetComponent<WinPanel>().OpenPanel();
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
