using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : Scene
{
    /// <summary>
    /// действия меню
    /// </summary>
    private void Update()
    {
        ShowInterface();
        LoadScene(1);
    }
}
