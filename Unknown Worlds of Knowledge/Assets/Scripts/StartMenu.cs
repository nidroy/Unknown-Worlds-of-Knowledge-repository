using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : Scene
{
    private void Start()
    {
        Settings.GetSettings();
        Settings.GetLocalizedText(Settings.settings[7]);
    }
}
