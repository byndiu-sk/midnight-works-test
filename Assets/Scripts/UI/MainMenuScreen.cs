using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScreen : BaseScreen
{
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button exitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayButtonClick);
        exitButton.onClick.AddListener(OnExtiButtonlClick);
    }

    private void OnPlayButtonClick()
    {
        SceneManager.LoadScene("Game");
    }

    private void OnExtiButtonlClick()
    {
        Application.Quit();
    }

}
