using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : Scene
{
    public Settings settings; // ���������

    /// <summary>
    /// ���������� ��������� ���������
    /// </summary>
    private void Start()
    {
        
    }

    /// <summary>
    /// �������� ����
    /// </summary>
    private void Update()
    {
        ShowInterface();
        LoadScene(1);
    }
}
