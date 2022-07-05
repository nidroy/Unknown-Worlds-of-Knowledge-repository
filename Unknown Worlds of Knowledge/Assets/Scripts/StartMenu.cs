using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : Scene
{
    public Settings settings; // настройки

    /// <summary>
    /// установить начальные настройки
    /// </summary>
    private void Start()
    {
        settings.SetLocalization();
    }

    /// <summary>
    /// действия меню
    /// </summary>
    private void Update()
    {
        ShowInterface();
        LoadScene(1);
    }
}
