using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : Scene
{
    /// <summary>
    /// �������� ����
    /// </summary>
    private void Update()
    {
        ShowInterface();
        LoadScene(1);
    }
}
