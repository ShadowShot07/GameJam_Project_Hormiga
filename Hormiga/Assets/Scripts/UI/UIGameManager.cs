using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameManager : MonoBehaviour
{
    [SerializeField] private Button _MainMenu;
    void Start()
    {
        _MainMenu.onClick.AddListener(LoadMainMenu);
    }
    
    private void OpenOptions()
    {

    }

    private void LoadMainMenu()
    {
        ScenesManager.instance.LoadMainMenu();
    }
}
