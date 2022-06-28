using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject uploadObject; // ������ ��������
    public Animator anim; // �������� ���������� ����

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
        isStart = true;
    }

    /// <summary>
    /// �������� � ����
    /// </summary>
    private void Update()
    {
        ShowInterface();
        LoadGame();
    }

    #region ������ ������ Update

    /// <summary>
    /// �������� ����������� ��������� ����
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
    /// ��������� ����
    /// </summary>
    private void LoadGame()
    {
        if (uploadObject.activeInHierarchy)
        {
            SceneManager.LoadScene(1);
        }
    }

    #endregion
}
