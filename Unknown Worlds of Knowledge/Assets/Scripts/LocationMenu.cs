using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationMenu : MonoBehaviour
{
    public GameObject startObject; // ������ ������ ����
    public Animator anim; // �������� ���� � ���������

    public Player player; // �����

    private bool isStart; // ������ ����

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
