using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameMenu : MonoBehaviour
{
    [Header("Botones del menu")]
    [SerializeField] private Button _backToGame;
    [SerializeField] private Button _exitToGame;

    [Header("Menu")]
    [SerializeField] private GameObject _optionMenu;

    private Movement _pauseInput;
    private bool isPaused;

    private void Awake()
    {
        _pauseInput = new();
        _pauseInput.Player.Enable();
        isPaused = false;
        ActiveTrueFalse.Activefalse(_optionMenu);
    }
    void Start()
    {
        _backToGame.onClick.AddListener(BackToGame);
        _exitToGame.onClick.AddListener(CloseGame);
    }

    private void Update()
    {
        OpenMenu();
    }

    private void OpenMenu()
    {
        if (_pauseInput.Player.Esc.WasPressedThisFrame())
        {
            if (isPaused)
            {
                BackToGame();
            } else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        ActiveTrueFalse.ActiveTrue(_optionMenu);
        Time.timeScale = 0f;
        isPaused = true;
    }

    private void BackToGame()
    {
        ActiveTrueFalse.Activefalse(_optionMenu);
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void CloseGame()
    {
        ScenesManager.instance.ExitGame();
    }
}
