﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{

    public GameObject Player;
    public GameObject SpawnPoint;

    private int score;

    public string restartLevel;
    public string mainMenu;

    public GameObject DeathScreen;
    public bool deathScreenActive = false;
    public static bool deathScreenNotifier;
    public static bool continueTrue;

    void Start()
    {
        Player = GameObject.Find("Player");
        SpawnPoint = GameObject.Find("RespawnPoint");
    }


    void Update()
    {
        score = ScoringSystem.score;

        if (deathScreenActive == true)
        {
            Instantiate(DeathScreen, transform.position, transform.rotation);
            deathScreenActive = false;
        }
    }



    public void StartGame()
    {
        continueTrue = false;
        SceneManager.LoadScene(restartLevel);
        Player.GetComponent<PlayerController>().ResetVar();
        Player.GetComponent<Hearts>().ResetVar();
        ScoringSystem.previousScore = 0;
        Hide();

    }

    public void ContinueGame()
    {

        continueTrue = true;
        SceneManager.LoadScene(restartLevel);
        Player.GetComponent<PlayerController>().ResetVar();
        Player.GetComponent<Hearts>().ResetVar();
        ScoringSystem.previousScore = score;
        Hide();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void Hide()
    {
        Destroy(DeathScreen);
    
    }

    public void Show()
    {
        deathScreenActive = true;
        deathScreenNotifier = true;
        Time.timeScale = 0;
    }
}
