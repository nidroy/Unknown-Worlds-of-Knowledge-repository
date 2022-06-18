using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Player player; // игрок

    /// <summary>
    /// действия игрока
    /// </summary>
    private void Update()
    {
        #region перемещение игрока
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
    /// функция перемещения вправо
    /// </summary>
    private void RightMovement()
    {
        player.direction = 1;
    }

    /// <summary>
    /// функция перемещения влево
    /// </summary>
    private void LeftMovement()
    {
        player.direction = -1;
    }

    /// <summary>
    /// функция останови перемещения
    /// </summary>
    private void StopMovement()
    {
        player.direction = 0;
    }

}
