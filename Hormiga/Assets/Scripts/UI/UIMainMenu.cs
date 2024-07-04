using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [Header("Botones")]
    [SerializeField] private Button _startGame;
    [SerializeField] private Button _options;
    [SerializeField] private Button _credits;
    [SerializeField] private Button _closeGame;
    [SerializeField] private Button _optionsToMenu;
    [SerializeField] private Button _creditsToMenu;

    [Header("Menus")]
    [SerializeField] private GameObject _mainMenuCanvas;
    [SerializeField] private GameObject _menuOptions;
    [SerializeField] private GameObject _menuCredits;

    void Start()
    {
        _startGame.onClick.AddListener(StartGame);
        _options.onClick.AddListener(StartOptions);
        _credits.onClick.AddListener(StartCredits);
        _closeGame.onClick.AddListener(CloseGame);
        _optionsToMenu.onClick.AddListener(OptionsToMenu);
        _creditsToMenu.onClick.AddListener(CreditsToMenu);
    }

    private void StartGame()
    {
        ScenesManager.instance.LoadNewGame();
    }

    private void StartOptions()
    {
        _mainMenuCanvas.SetActive(false);
        _menuOptions.SetActive(true);
    }

    private void StartCredits()
    {
        _mainMenuCanvas.SetActive(false);
        _menuCredits.SetActive(true);
    }

    private void CloseGame()
    {
        Application.Quit();
    }

    private void OptionsToMenu()
    {
        _mainMenuCanvas.SetActive(true);
        _menuOptions.SetActive(false);
    }
    
    private void CreditsToMenu()
    {
        _mainMenuCanvas.SetActive(true);
        _menuCredits.SetActive(false);
    }
}