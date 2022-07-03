using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Scene : MonoBehaviour
{
    public new GameObject camera; // камера
    public GameObject uploadObject; // объект загрузки
    public Animator anim; // анимации начального меню

    private bool isStart = true; // начало работы сцены

    public bool isExit { private get; set; } = false; // выйти из игры?

    /// <summary>
    /// установить камеру на сцене
    /// </summary>
    public void SetCamera()
    {
        camera.transform.position = GameManager.cameraPosition;
    }

    /// <summary>
    /// скрыть графический интерфейс сцены
    /// </summary>
    public void HideInterface()
    {
        anim.SetBool("isHideInterface", true);
    }

    /// <summary>
    /// показать графический интерфейс сцены
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
    /// загрузить сцену
    /// </summary>
    /// <param name="location">сцена</param>
    public void LoadScene(int scene)
    {
        if (uploadObject.activeInHierarchy)
        {
            ExitGame();
            SceneManager.LoadScene(scene);
        }
    }

    /// <summary>
    /// выйти из игры
    /// </summary>
    private void ExitGame()
    {
        if(isExit)
            Application.Quit();
    }
}
