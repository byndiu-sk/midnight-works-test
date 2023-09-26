using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : BaseScreen
{
    [SerializeField]
    private Button pauseButton;

    private void Awake()
    {
        pauseButton.onClick.AddListener(OnPauseButtonClick);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPauseButtonClick();
        }
    }
    private void OnPauseButtonClick()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        ScreenController.Instance.GetScreen<PauseScreen>().Open();
        Close();
    }
}
