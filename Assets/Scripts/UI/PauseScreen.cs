using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : BaseScreen
{
    [SerializeField]
    private Button resumeButton;
    [SerializeField]
    private Button mainMenuButton;

    private void Awake()
    {
        resumeButton.onClick.AddListener(OnResumeButtonClick);
        mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
    }

    private void Update()
    {
    }

    private void OnResumeButtonClick()
    {
        Time.timeScale = 1.0f;
        Close();
    }

    private void OnMainMenuButtonClick()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
}
