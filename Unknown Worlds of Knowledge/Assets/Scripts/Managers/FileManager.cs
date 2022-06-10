using UnityEngine;
using System.IO;

public class FileManager : MonoBehaviour
{
    public static string pathToSettings = Application.dataPath + "/Settings/settings.txt"; // ���� � ����� � �����������
    public static string pathToLocalization = Application.dataPath + "/Localizations/EN.txt"; // ���� � ����� � ������������

    /// <summary>
    /// ������ �����
    /// </summary>
    /// <param name="filePath">���� � �����</param>
    /// <returns>���������� �����</returns>
    public static string ReadingFile(string filePath)
    {
        StreamReader sr = new StreamReader(filePath);

        string result = "";

        while (sr.EndOfStream != true)
        {
            result += sr.ReadLine() + "\n";
        }

        sr.Close();

        return result.Remove(result.Length - 1);
    }

    /// <summary>
    /// ������ � ����
    /// </summary>
    /// <param name="filePath">���� � �����</param>
    /// <param name="text">������ ��� ������ � ����</param>
    public static void WritingFile(string filePath, string text)
    {
        FileStream file = new FileStream(filePath, FileMode.Create);
        StreamWriter writer = new StreamWriter(file);
        writer.Write(text);
        writer.Close();
    }
}
