﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public HudController hud;

    public PlayerSpawner playerSpawner;

    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI gameOverTxt;
    public TextMeshProUGUI restartGameTxt;

    public bool gameOver;

    private int score;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        ResetHud();
        gameOver = false;
        hud.ShowHud();
        playerSpawner.SpawnPlayer();
    }

    public void ShowMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (gameOver)
        {
            if(Input.GetKey(KeyCode.R))
            {
                RestartGame();
            }
            else if(Input.GetKey(KeyCode.M))
            {
                ShowMenu();
            }
        }
    }

    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreTxt.text = "Score: " + score;
    }

    public void GameOver()
    {
        restartGameTxt.enabled = true;
        gameOverTxt.enabled = true;
        gameOver = true;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ResetHud()
    {
        score = 0;
        scoreTxt.text = "Score: " + score;

        restartGameTxt.enabled = false;
        gameOverTxt.enabled = false;
        gameOver = false;
    }
}
