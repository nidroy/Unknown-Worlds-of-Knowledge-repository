using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationMenu : Scene
{
    public GameObject playerMoveObject; // ������ ��� ������ �������� ������

    public Player player; // �����

    public int downloadLocation { private get; set; } // ������� ��� ��������

    /// <summary>
    /// ���������� ����������
    /// </summary>
    private void Start()
    {
        downloadLocation = 0;
    }

    /// <summary>
    /// �������� ���� �������
    /// </summary>
    private void Update()
    {
        ShowInterface();
        PlayerMove();
        LoadScene(downloadLocation);
    }

    /// <summary>
    /// ��������� ������ ���������
    /// </summary>
    private void PlayerMove()
    {
        if (playerMoveObject.activeInHierarchy)
        {
            player.isMove = true;
        }
    }
}
