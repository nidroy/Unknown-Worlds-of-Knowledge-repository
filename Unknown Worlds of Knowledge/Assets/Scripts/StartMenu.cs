using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Animator anim;

    private bool isStart;

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
    }
}
