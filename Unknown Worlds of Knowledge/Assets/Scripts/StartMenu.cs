using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject uploadObject; // объект загрузки
    public Animator anim; // анимации начального меню

    private bool isStart; // начало игры

    public void StartGame()
    {
        anim.SetBool("isHideInterface", true);
    }

    private void Start()
    {
        isStart = true;
    }
    private void Update()
    {
        if(isStart && Input.anyKey)
        {
            anim.SetBool("isShowInterface", true);
            isStart = false;
        }
        if(uploadObject.activeInHierarchy)
        {
            SceneManager.LoadScene(1);
        }
    }
}
