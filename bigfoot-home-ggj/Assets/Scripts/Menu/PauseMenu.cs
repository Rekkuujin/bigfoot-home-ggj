﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MainMenu {

    private bool paused = false;
    GameObject pauseMenu;

    void Start()
    {
        pauseMenu = GameObject.Find("Menu");
        pauseMenu.SetActive(false);
    }

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = TogglePause();
        }
	}

    bool TogglePause()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        if (!paused)
        {
            Time.timeScale = 0f;
            return true;
        }
        else
        {
            Time.timeScale = 1f;
            return false;
        }
    }

    public void ResumeButton(){
        paused = TogglePause();
    }

    public void ReturnToTitleButton(){
        SceneManager.LoadScene(0);
    }
}