using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationMenu : MonoBehaviour
{
    public GameObject startObject; // объект начала игры
    public GameObject uploadObject; // объект загрузки
    public Animator anim; // анимации меню с локациями

    public Player player; // игрок

    public int downloadLocation { private get; set; } // локация для загрузки

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
        downloadLocation = 0;
        isStart = true;
    }

    /// <summary>
    /// действия в меню локаций
    /// </summary>
    private void Update()
    {
        ShowInterface();
        PlayerMove();
        LoadLocation(downloadLocation);
    }

    #region методы внутри Update

    /// <summary>
    /// показать графический интерфейс меню локаций
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
    /// позволить игроку двигаться
    /// </summary>
    private void PlayerMove()
    {
        if (startObject.activeInHierarchy)
        {
            player.isMove = true;
        }
    }

    /// <summary>
    /// загрузить локацию
    /// </summary>
    /// <param name="location">локация</param>
    private void LoadLocation(int location)
    {
        if (uploadObject.activeInHierarchy)
        {
            SceneManager.LoadScene(location);
        }
    }

    #endregion
}
