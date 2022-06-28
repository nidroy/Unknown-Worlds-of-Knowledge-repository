using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject uploadObject; // объект загрузки
    public Animator anim; // анимации начального меню

    private bool isStart; // начало работы сцены

    /// <summary>
    /// начать игру
    /// </summary>
    public void StartGame()
    {
        anim.SetBool("isHideInterface", true);
    }

    /// <summary>
    /// установить переменные
    /// </summary>
    private void Start()
    {
        isStart = true;
    }

    /// <summary>
    /// действия в меню
    /// </summary>
    private void Update()
    {
        ShowInterface();
        LoadGame();
    }

    #region методы внутри Update

    /// <summary>
    /// показать графический интерфейс меню
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
    /// загрузить игру
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
