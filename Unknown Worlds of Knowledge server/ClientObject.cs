using System;
using System.Net.Sockets;
using System.Text;

namespace Unknown_Worlds_of_Knowledge_server
{
    public class ClientObject
    {
        private string userName; // имя клиента 
        private TcpClient client; // объект TCP клиента
        private ServerObject server; // объект сервера

        public string Id { get; private set; } // id клиента
        public NetworkStream Stream { get; private set; } // поток данных

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="tcpClient">объект TCP клиента</param>
        /// <param name="serverObject">объект сервера</param>
        public ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
            serverObject.AddConnection(this);
        }

        /// <summary>
        /// получение и отправка сообщений клиентам
        /// </summary>
        public void Process()
        {
            try
            {
                Stream = client.GetStream(); // получение потока данных
                string message = GetMessage(); // плучаем имя клиента
                userName = message; // записываем имя клиента

                message = String.Format("{0} is connected", userName); // формируем сообщение
                server.BroadcastMessageEveryone(message, this.Id); // посылаем сообщение о входе на сервер всем подключенным пользователям
                Console.WriteLine(message); // выводим сообщение на экран
                while (true) // в бесконечном цикле получаем сообщения от клиента
                {
                    try
                    {
                        message = GetMessage(); // получаем сообщение
                        message = String.Format("{0}: {1}", userName, message); // построение сообщения
                        Console.WriteLine(message); // вывод на экран сервера
                        server.BroadcastMessageEveryone(message, this.Id); // передача сообщения другим клиентам
                    }
                    catch
                    {
                        message = String.Format("{0} disconnected", userName);
                        Console.WriteLine(message);
                        server.BroadcastMessageEveryone(message, this.Id);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                server.RemoveConnection(this.Id);
                Close();
            }
        }

        /// <summary>
        /// чтение входящего сообщения и преобразование в строку
        /// </summary>
        /// <returns>сообщение</returns>
        private string GetMessage()
        {
            byte[] data = new byte[64]; // буфер для получаемых данных
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = Stream.Read(data, 0, data.Length); // читаем байты из потока данных
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes)); // строим из байт текст
            }
            while (Stream.DataAvailable);

            return builder.ToString(); // выводим сообщение
        }

        /// <summary>
        /// закрытие подключения
        /// </summary>
        public void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (client != null)
                client.Close();
        }
    }
}
