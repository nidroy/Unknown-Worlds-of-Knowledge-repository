using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Image time; // время
    public Text timeText; // текст времени
    public bool isStart { get; set; } = false; // начало запуска таймера

    /// <summary>
    /// сброс таймера
    /// </summary>
    public void Reset()
    {
        time.fillAmount = 1;
    }

    /// <summary>
    /// действия таймера
    /// </summary>
    private void Update()
    {
        TimeCounting();
    }

    /// <summary>
    /// отсчет времени
    /// </summary>
    private void TimeCounting()
    {
        if (isStart)
        {
            time.fillAmount -= Time.deltaTime / 10;
            timeText.text = ((int)(time.fillAmount * 11)).ToString();
        }
    }
}
