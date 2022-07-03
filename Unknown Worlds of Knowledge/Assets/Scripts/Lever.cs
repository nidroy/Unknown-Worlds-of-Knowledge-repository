using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public int number; // номер рычага
    public GameObject useObject; // объект для возможности использовать

    public Animator[] anim; // анимации рычагов
    public GameObject[] portal; // порталы

    private bool isPress; // можно ли нажать на рычаг?

    /// <summary>
    /// установить переменные
    /// </summary>
    private void Start()
    {
        isPress = false;
    }

    /// <summary>
    /// нажать на рычаг
    /// </summary>
    private void Update()
    {
        if (isPress && Input.GetKeyDown(KeyCode.E))
            Press();
    }

    /// <summary>
    /// нажатие
    /// </summary>
    private void Press()
    {
        Reset(number - 1);
        if (anim[number - 1].GetBool("isOn"))
        {
            anim[number - 1].SetBool("isOn", false);
            portal[number - 1].SetActive(false);
        }
        else
        {
            anim[number - 1].SetBool("isOn", true);
            portal[number - 1].SetActive(true);
        }
    }

    /// <summary>
    /// сброс нажатий
    /// </summary>
    /// <param name="number">номер рычага</param>
    private void Reset(int number)
    {
        for(int i = 0; i < 4; i++)
        {
            if (i != number)
            {
                anim[i].SetBool("isOn", false);
                portal[i].SetActive(false);
            }
        }
    }

    /// <summary>
    /// коснуться объекта
    /// </summary>
    /// <param name="collision">объект касания</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPress = true;
            useObject.SetActive(true);
        }
    }

    /// <summary>
    /// перестать касаться объекта
    /// </summary>
    /// <param name="collision">объект касания</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPress = false;
            useObject.SetActive(false);
        }
    }
}
