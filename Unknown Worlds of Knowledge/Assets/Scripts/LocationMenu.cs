using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationMenu : MonoBehaviour
{
    public GameObject startObject; // ������ ������ ����
    public GameObject uploadObject; // ������ ��������
    public Animator anim; // �������� ���� � ���������

    public Player player; // �����

    public int downloadLocation { private get; set; } // ������� ��� ��������

    private bool isStart; // ������ ������ �����

    /// <summary>
    /// ������ ����
    /// </summary>
    public void StartGame()
    {
        anim.SetBool("isHideInterface", true);
    }

    /// <summary>
    /// ���������� ����������
    /// </summary>
    private void Start()
    {
        downloadLocation = 0;
        isStart = true;
    }

    /// <summary>
    /// �������� � ���� �������
    /// </summary>
    private void Update()
    {
        ShowInterface();
        PlayerMove();
        LoadLocation(downloadLocation);
    }

    #region ������ ������ Update

    /// <summary>
    /// �������� ����������� ��������� ���� �������
    /// </summary>
    private void ShowInterface()
    {
        if (isStart && Input.anyKey)
        {
            anim.SetBool("isShowInterface", true);
            isStart = false;
        }
    }

    /// <summary>
    /// ��������� ������ ���������
    /// </summary>
    private void PlayerMove()
    {
        if (startObject.activeInHierarchy)
        {
            player.isMove = true;
        }
    }

    /// <summary>
    /// ��������� �������
    /// </summary>
    /// <param name="location">�������</param>
    private void LoadLocation(int location)
    {
        if (uploadObject.activeInHierarchy)
        {
            SceneManager.LoadScene(location);
        }
    }

    #endregion
}
