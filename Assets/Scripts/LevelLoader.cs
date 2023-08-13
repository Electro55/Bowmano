using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : GameSingleton<LevelLoader>
{
    [SerializeField]
    private int levels = 5;

    private int currentLevel = 0;

    public void StartNewGame()
    {
        currentLevel = 0;
        LoadLevel(currentLevel);
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(currentLevel + 1);
    }

    public void LoadMenu()
    {
        currentLevel = 0;
        SceneManager.LoadScene("Menu");
    }

    public void LoadNextLevel()
    {
        currentLevel++;
        if (currentLevel < levels)
            LoadLevel(currentLevel);
        else
            LoadMenu();
    }


}
