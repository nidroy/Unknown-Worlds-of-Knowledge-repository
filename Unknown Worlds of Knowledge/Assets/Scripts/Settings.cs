using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public static string[] localizedText; // ���������������� �����

    public static string[] settings; // ��������� �� �����

    public Slider musicVolume; // ��������� ������
    public Slider soundsVolume; // ��������� ������
    public string screenMode; // ����� ������
    public Dropdown screenResolution; // ���������� ������
    public string localization; // �����������

    /// <summary>
    /// ���������� �����������
    /// </summary>
    /// <param name="localization">�������� �����������</param>
    public void SetLocalization(string localization)
    {
        FileManager.pathToLocalization = String.Format(Application.dataPath + "/Localizations/{0}.txt", localization);
        localizedText = FileManager.ReadingFile(FileManager.pathToLocalization).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
    }

    public void GetSettings()
    {
        settings = FileManager.ReadingFile(FileManager.pathToSettings).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        musicVolume.value = float.Parse(settings[0]);
        soundsVolume.value = float.Parse(settings[1]);
        screenMode = settings[2];
        screenResolution.value = int.Parse(settings[3]);
        localization = settings[4];
    }

    public void SetSettings()
    {

    }
}
