using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    // словарь кнопок управления
    private static Dictionary<string, KeyCode> controlKey = new Dictionary<string, KeyCode>()
    {
        ["rightMovement"] = KeyCode.D,
        ["leftMovement"] = KeyCode.A,
        ["use"] = KeyCode.E
    };

    // массив кодов кнопок
    private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));

    /// <summary>
    /// установить кнопку управления
    /// </summary>
    /// <param name="key">название кнопки</param>
    public void SetControlKey(string key)
    {
        if(Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in keyCodes)
            {
                if (Input.GetKey(keyCode))
                {
                    controlKey[key] = keyCode;
                }
            }
        }
    }
}
