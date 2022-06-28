using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public int number; // номер портала

    public LocationMenu menu; // меню локации
    public GameObject teleport; // телепорт портала

    /// <summary>
    /// коснуться объекта
    /// </summary>
    /// <param name="collision">объект касания</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && teleport.activeInHierarchy)
        {
            menu.StartGame();
            menu.downloadLocation = number + 1;
        }
    }
}
