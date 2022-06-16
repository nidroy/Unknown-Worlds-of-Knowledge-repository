using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Text[] textMenu; // ������� � ������� ��� �����������

    public static string[] localizedText; // ���������������� �����

    /// <summary>
    /// ���������� �����������
    /// </summary>
    /// <param name="localization">�������� �����������</param>
    public void SetLocalization(string localization)
    {
        FileManager.pathToLocalization = String.Format(Application.dataPath + "/Localizations/{0}.txt", localization);
        localizedText = FileManager.ReadingFile(FileManager.pathToLocalization).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < 7; i++)
        {
            textMenu[i].text = localizedText[i];
        }
    }
}
