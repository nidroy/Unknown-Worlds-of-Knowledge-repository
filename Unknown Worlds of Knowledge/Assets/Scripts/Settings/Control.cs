using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    // ������� ������ ����������
    private static Dictionary<string, KeyCode> controlKey = new Dictionary<string, KeyCode>()
    {
        ["rightMovement"] = KeyCode.D,
        ["leftMovement"] = KeyCode.A,
        ["use"] = KeyCode.E
    };

    // ������ ����� ������
    private readonly Array keyCodes = Enum.GetValues(typeof(KeyCode));

    /// <summary>
    /// ���������� ������ ����������
    /// </summary>
    /// <param name="key">�������� ������</param>
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
