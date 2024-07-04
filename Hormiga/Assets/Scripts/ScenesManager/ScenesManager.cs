using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance;

    private void Awake()
    {
        instance = this;
    }

    public enum Scene
    {
        PruebaMenuSceneManager,
        Prueba1,
        Prueba2,
        Prueba3
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.Prueba1.ToString());
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.PruebaMenuSceneManager.ToString());
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
