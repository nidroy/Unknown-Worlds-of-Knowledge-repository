using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Scene : MonoBehaviour
{
    public new GameObject camera; // ������
    public GameObject uploadObject; // ������ ��������
    public Animator anim; // �������� ���������� ����

    private bool isStart = true; // ������ ������ �����

    public bool isExit { private get; set; } = false; // ����� �� ����?

    /// <summary>
    /// ���������� ������ �� �����
    /// </summary>
    public void SetCamera()
    {
        camera.transform.position = GameManager.cameraPosition;
    }

    /// <summary>
    /// ������ ����������� ��������� �����
    /// </summary>
    public void HideInterface()
    {
        anim.SetBool("isHideInterface", true);
    }

    /// <summary>
    /// �������� ����������� ��������� �����
    /// </summary>
    public void ShowInterface()
    {
        if (isStart && Input.anyKey)
        {
            anim.SetBool("isShowInterface", true);
            isStart = false;
        }
    }

    /// <summary>
    /// ��������� �����
    /// </summary>
    /// <param name="location">�����</param>
    public void LoadScene(int scene)
    {
        if (uploadObject.activeInHierarchy)
        {
            ExitGame();
            SceneManager.LoadScene(scene);
        }
    }

    /// <summary>
    /// ����� �� ����
    /// </summary>
    private void ExitGame()
    {
        if(isExit)
            Application.Quit();
    }
}
