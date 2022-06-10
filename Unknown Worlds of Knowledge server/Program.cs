using System;

namespace Unknown_Worlds_of_Knowledge_server
{
    public class Program
    {
        private static ServerObject server; // объект сервера
        private static Thread listenThread; // поток для ожидания подключений

        /// <summary>
        /// запуск сервера в отдельном потоке
        /// </summary>
        /// <param name="args">аргументы</param>
        private static void Main(string[] args)
        {
            try
            {
                server = new ServerObject(); // создание объекта
                listenThread = new Thread(new ThreadStart(server.Listen)); // создание отдельного потока
                listenThread.Start(); //запуск потока
            }
            catch (Exception ex) // в случае возникновения ошибки
            {
                server.Disconnect(); // выключаем сервер
                Console.WriteLine(ex.Message); // выводим текст ошибки на экран
            }
        }
    }
}