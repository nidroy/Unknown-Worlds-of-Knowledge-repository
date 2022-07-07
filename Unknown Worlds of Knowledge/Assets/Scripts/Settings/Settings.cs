using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public static string[] localizedText; // локализированный текст

    public static string[] settings; // настройки из файла

    public Slider[] volume; // громкость
    private string screenMode; // режим экрана
    public Dropdown screenResolution; // разрашение экрана
    public Text[] controlKey; // кнопки управления
    private string localization; // локализация

    public GameObject[] flag; // флаги в радиобаттонах

    public void Update()
    {
        Display.SetScreenResolution(screenResolution.value, screenMode);
    }

    public static void GetSettings()
    {
        settings = FileManager.ReadingFile(FileManager.pathToSettings).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
    }

    public static void GetLocalizedText(string localization)
    {
        FileManager.pathToLocalization = String.Format(Application.dataPath + "/Localizations/{0}.txt", localization);
        localizedText = FileManager.ReadingFile(FileManager.pathToLocalization).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
    }

    public void SetSettings()
    {
        for (int i = 0; i < 2; i++)
            settings[i] = volume[i].value.ToString();
        settings[2] = screenMode;
        settings[3] = screenResolution.value.ToString();
        for (int i = 0; i < 3; i++)
            settings[i + 4] = controlKey[i].text;
        settings[7] = localization;

        SaveSettings(settings);
    }

    private void SaveSettings(string[] settings)
    {
        string data = "";
        for(int i = 0; i < settings.Length; i++)
            data += settings[i] + "\n";
        FileManager.WritingFile(FileManager.pathToSettings, data.Remove(data.Length - 1));
    }

    public void DisplaySettings()
    {
        for(int i = 0; i < 2; i++)
            volume[i].value = float.Parse(settings[i]);
        screenMode = settings[2];
        screenResolution.value = int.Parse(settings[3]);
        for(int i = 0; i < 3; i++)
            controlKey[i].text = settings[i + 4];
        localization = settings[7];

        SetScreenMode(screenMode);
        SetLocalization(localization);
    }

    public void SetScreenMode(string screenMode)
    {
        this.screenMode = screenMode;

        if(screenMode == "fullscreen")
        {
            flag[0].SetActive(true);
            flag[1].SetActive(false);
        }
        else
        {
            flag[0].SetActive(false);
            flag[1].SetActive(true);
        }
    }

    public void SetLocalization(string localization)
    {
        this.localization = localization;

        if (localization == "RU")
        {
            flag[2].SetActive(true);
            flag[3].SetActive(false);
            flag[4].SetActive(false);
            flag[5].SetActive(true);
        }
        else
        {
            flag[2].SetActive(false);
            flag[3].SetActive(true);
            flag[4].SetActive(true);
            flag[5].SetActive(false);
        }

        GetLocalizedText(localization);
    }
}
