using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public int number; // ����� �������

    public LocationMenu menu; // ���� �������
    public GameObject teleport; // �������� �������

    /// <summary>
    /// ��������� �������
    /// </summary>
    /// <param name="collision">������ �������</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && teleport.activeInHierarchy)
        {
            menu.StartGame();
            menu.downloadLocation = number + 1;
        }
    }
}
