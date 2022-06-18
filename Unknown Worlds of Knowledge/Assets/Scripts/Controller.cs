using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Player player; // �����

    /// <summary>
    /// �������� ������
    /// </summary>
    private void Update()
    {
        #region ����������� ������
        if (Input.GetKey(KeyCode.D))
        {
            RightMovement();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            LeftMovement();
        }
        else
        {
            StopMovement();
        }
        #endregion
    }


    /// <summary>
    /// ������� ����������� ������
    /// </summary>
    private void RightMovement()
    {
        player.direction = 1;
    }

    /// <summary>
    /// ������� ����������� �����
    /// </summary>
    private void LeftMovement()
    {
        player.direction = -1;
    }

    /// <summary>
    /// ������� �������� �����������
    /// </summary>
    private void StopMovement()
    {
        player.direction = 0;
    }

}
