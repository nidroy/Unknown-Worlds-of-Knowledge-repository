using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class Proxy : MonoBehaviour
{
    private static string userName;
    private const string host = "127.0.0.1"; // ip адре сервера 
    private const int port = 8888; // порт который прослушивает сервер
    private static TcpClient client; // объект TCP клиента
    private static NetworkStream stream; // поток данных

    /// <summary>
    /// соединить с сервером
    /// </summary>
    private void Start()
    {
        Connection(userName);
    }

    /// <summary>
    /// функция соединения с сервером
    /// </summary>
    /// <param name="userName">имя клиента</param>
    private void Connection(string userName)
    {
        client = new TcpClient();
        try
        {
            client.Connect(host, port);
            stream = client.GetStream();

            byte[] data = Encoding.Unicode.GetBytes(userName);
            stream.Write(data, 0, data.Length);

            Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
            receiveThread.Start();
            Debug.Log(String.Format("{0} is connected", userName));
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }
    
    /// <summary>
    /// отправка сообщения
    /// </summary>
    /// <param name="message">сообщение</param>
    public new void SendMessage(string message)
    {
        byte[] data = Encoding.Unicode.GetBytes(message);
        stream.Write(data, 0, data.Length);
    }
    
    /// <summary>
    /// получение сообщений
    /// </summary>
    private void ReceiveMessage()
    {
        while (true)
        {
            try
            {
                byte[] data = new byte[64];
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = stream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable == false && bytes == 0);

                string message = builder.ToString();
                Debug.Log(message);
            }
            catch
            {
                Debug.Log("Connection interrupted");
                Disconnect();
                return;
            }
        }
    }

    /// <summary>
    /// отключение от сервера
    /// </summary>
    public void Disconnect()
    {
        if (stream != null)
            stream.Close();
        if (client != null)
            client.Close();
    }
}
