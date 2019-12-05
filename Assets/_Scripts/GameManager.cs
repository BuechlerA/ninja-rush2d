using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GUIManager guiManager;
    public GameStates gameStates;

    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        guiManager = GetComponent<GUIManager>();
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
                break;
            default:
                break;
        }
    }
}
