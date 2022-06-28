using UnityEngine;
using UnityEngine.SceneManagement;

public class LocationMenu : Scene
{
    public GameObject playerMoveObject; // объект для начала движения игрока

    public Player player; // игрок

    public int downloadLocation { private get; set; } // локация для загрузки

    /// <summary>
    /// установить переменные
    /// </summary>
    private void Start()
    {
        downloadLocation = 0;
    }

    /// <summary>
    /// действия меню локаций
    /// </summary>
    private void Update()
    {
        ShowInterface();
        PlayerMove();
        LoadScene(downloadLocation);
    }

    /// <summary>
    /// позволить игроку двигаться
    /// </summary>
    private void PlayerMove()
    {
        if (playerMoveObject.activeInHierarchy)
        {
            player.isMove = true;
        }
    }
}
