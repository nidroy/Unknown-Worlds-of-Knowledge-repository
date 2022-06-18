using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationMenu : MonoBehaviour
{
    public GameObject startObject; // объект начала игры
    public Animator anim; // анимации меню с локациями

    public Player player; // игрок

    private bool isStart; // начало игры

    private void Start()
    {
        isStart = true;
    }
    private void Update()
    {
        if (isStart && Input.anyKey)
        {
            anim.SetBool("isShowInterface", true);
            isStart = false;
        }
        if(startObject.activeInHierarchy)
        {
            player.isMove = true;
        }
    }
}
