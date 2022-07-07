using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour
{
    // словарь разрешений экрана
    private readonly static Dictionary<int, string> screenResolutions = new Dictionary<int, string>()
    {
        [0] = "1280x1024",
        [1] = "1366x768",
        [2] = "1440x900",
        [3] = "1600x900",
        [4] = "1680x1050",
        [5] = "1920x1080",
        [6] = "1920x1200",
        [7] = "2560x1080",
        [8] = "2560x1440",
        [9] = "3440x1440",
        [10] = "3840x2160",
        [11] = "4096x2160",
        [12] = "5120x2880"
    };

    /// <summary>
    /// установить разрешение экрана
    /// </summary>
    /// <param name="number">номер разрешения</param>
    /// <param name="screenMode">режим экрана</param>
    public static void SetScreenResolution(int number, string screenMode)
    {
        string[] screenResolution = screenResolutions[number].Split(new char[] { 'x' }, StringSplitOptions.RemoveEmptyEntries);

        if(screenMode == "fullscreen")
            Screen.SetResolution(int.Parse(screenResolution[0]), int.Parse(screenResolution[1]), true);
        else
            Screen.SetResolution(int.Parse(screenResolution[0]), int.Parse(screenResolution[1]), false);
    }
}
