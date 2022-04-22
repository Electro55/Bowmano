using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private MenuScreen currentScreen;

    private void Start()
    {
        currentScreen?.Enable();
    }

    public void OpenScreen(MenuScreen newScreen)
    {
        currentScreen.Disable();
        newScreen.Enable();
        currentScreen = newScreen;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadWorld()
    {
        LevelLoader.Instance.LoadLevel(0);
    }
}
