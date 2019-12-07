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

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        gameOverPanel = GameObject.Find("GameGUI").GetComponentInChildren<GameOverPanel>();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        gameOverPanel.OpenPanel();
    }
}
