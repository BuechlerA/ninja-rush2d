using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    private GameManager gameManager;

    private GameOverPanel gameOverPanel;

    private Scene currentScene;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        gameOverPanel = GameObject.Find("GameGUI").GetComponentInChildren<GameOverPanel>();

        currentScene = SceneManager.GetActiveScene();
        Debug.Log(currentScene.ToString() + currentScene.buildIndex);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    public void GameOver()
    {
        gameOverPanel.OpenPanel();
    }
}
