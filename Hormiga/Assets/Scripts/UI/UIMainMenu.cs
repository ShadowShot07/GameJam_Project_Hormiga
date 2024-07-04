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
        ActiveTrueFalse.ActiveTrue(_mainMenuCanvas);
        ActiveTrueFalse.Activefalse(_menuOptions);
        ActiveTrueFalse.Activefalse(_menuCredits);
        Listeners();
    }

    private void StartGame()
    {
        ScenesManager.instance.LoadNewGame();
    }

    private void StartOptions()
    {
        ActiveTrueFalse.Activefalse(_mainMenuCanvas);
        ActiveTrueFalse.ActiveTrue(_menuOptions);
    }

    private void StartCredits()
    {
        ActiveTrueFalse.Activefalse(_mainMenuCanvas);
        ActiveTrueFalse.ActiveTrue(_menuCredits);
    }

    private void OptionsToMenu()
    {
        ActiveTrueFalse.ActiveTrue(_mainMenuCanvas);
        ActiveTrueFalse.Activefalse(_menuOptions);
    }
    
    private void CreditsToMenu()
    {
        ActiveTrueFalse.ActiveTrue(_mainMenuCanvas);
        ActiveTrueFalse.Activefalse(_menuCredits);
    }

    private void CloseGame()
    {
        ScenesManager.instance.ExitGame();
    }

    private void Listeners()
    {
        _startGame.onClick.AddListener(StartGame);
        _options.onClick.AddListener(StartOptions);
        _credits.onClick.AddListener(StartCredits);
        _closeGame.onClick.AddListener(CloseGame);
        _optionsToMenu.onClick.AddListener(OptionsToMenu);
        _creditsToMenu.onClick.AddListener(CreditsToMenu);
    }
}