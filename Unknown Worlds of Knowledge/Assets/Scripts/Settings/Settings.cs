using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public static string[] localizedText; // ���������������� �����

    public static string[] settings; // ��������� �� �����

    public Slider[] volume; // ���������
    public string screenMode; // ����� ������
    public Dropdown screenResolution; // ���������� ������
    public Text[] controlKey; // ������ ����������
    public string localization; // �����������

    /// <summary>
    /// ���������� �����������
    /// </summary>
    /// <param name="localization">�������� �����������</param>
    public void SetLocalization(string localization)
    {
        this.localization = localization;
        FileManager.pathToLocalization = String.Format(Application.dataPath + "/Localizations/{0}.txt", localization);
        localizedText = FileManager.ReadingFile(FileManager.pathToLocalization).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
    }

    public void GetSettings()
    {
        settings = FileManager.ReadingFile(FileManager.pathToSettings).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        screenMode = settings[2];
        screenResolution.value = int.Parse(settings[3]);
        localization = settings[4];
    }

    public void SetSettings()
    {

    }
}
