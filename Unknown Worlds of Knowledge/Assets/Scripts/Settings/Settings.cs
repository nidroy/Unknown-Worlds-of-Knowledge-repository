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
    public string screenMode; // режим экрана
    public Dropdown screenResolution; // разрашение экрана
    public Text[] controlKey; // кнопки управления
    public string localization; // локализация

    /// <summary>
    /// установить локализацию
    /// </summary>
    /// <param name="localization">название локализации</param>
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
