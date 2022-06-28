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

    #region направление движения

    /// <summary>
    /// перемещение вправо
    /// </summary>
    private void RightMovement()
    {
        player.direction = 1;
    }

    /// <summary>
    /// перемещение влево
    /// </summary>
    private void LeftMovement()
    {
        player.direction = -1;
    }

    /// <summary>
    /// остановить перемещение
    /// </summary>
    private void StopMovement()
    {
        player.direction = 0;
    }

    #endregion
}
