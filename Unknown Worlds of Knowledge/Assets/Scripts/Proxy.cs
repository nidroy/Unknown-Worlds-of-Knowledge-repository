using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class Proxy : MonoBehaviour
{
    static string userName;
    private const string host = "127.0.0.1"; // ip ���� ������� 
    private const int port = 8888; // ���� ������� ������������ ������
    private static TcpClient client;
    private static NetworkStream stream;

    private void Start()
    {
        Connection();
    }

    private void Connection()
    {
        userName = "username";
        client = new TcpClient();
        try
        {
            client.Connect(host, port); //����������� ������� � �������
            stream = client.GetStream(); // �������� ������ ������

            byte[] data = Encoding.Unicode.GetBytes(userName); // ��������� ������� � �����
            stream.Write(data, 0, data.Length); // ���������� ����� � �����

            // ��������� ����� ����� ��� ��������� ������
            Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
            receiveThread.Start(); //����� ������
            Debug.Log(String.Format("����� ���������� {0}", userName));
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }
    // �������� ���������
    public void SendMessage()
    {
        string message = "ghbdtn";
        byte[] data = Encoding.Unicode.GetBytes(message);
        stream.Write(data, 0, data.Length);
    }
    // ��������� ���������
    private void ReceiveMessage()
    {
        while (true)
        {
            try
            {
                byte[] data = new byte[64]; // ����� ��� ���������� ������
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = stream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable == false && bytes == 0);

                string message = builder.ToString();
                Debug.Log(message);//����� ���������
            }
            catch
            {
                Debug.Log("����������� ��������!"); //���������� ���� ��������
                Disconnect();
                return;
            }
        }
    }

    public void Disconnect()
    {
        if (stream != null)
            stream.Close();//���������� ������
        if (client != null)
            client.Close();//���������� �������
    }
}
