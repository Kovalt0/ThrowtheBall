﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    bool on = false;

     void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        if (GameIsPaused)
            {
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
               GameIsPaused = false;
               //Resume();
            }
            else
            {
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                GameIsPaused = true;
                //Pause();
            }
        }

       
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
        // Debug.Log("Loading Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game");
    }

}