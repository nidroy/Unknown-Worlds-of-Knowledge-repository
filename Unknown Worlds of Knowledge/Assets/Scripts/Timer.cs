using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Image time; // �����
    public Text timeText; // ����� �������
    public bool isStart { get; set; } = false; // ������ ������� �������

    /// <summary>
    /// ����� �������
    /// </summary>
    public void Reset()
    {
        time.fillAmount = 1;
    }

    /// <summary>
    /// �������� �������
    /// </summary>
    private void Update()
    {
        TimeCounting();
    }

    /// <summary>
    /// ������ �������
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
