using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

namespace Unknown_Worlds_of_Knowledge_server
{
    public class ServerObject
    {
        private static TcpListener tcpListener; // сервер для прослушивания новых подключений
        private List<ClientObject> clients = new List<ClientObject>(); // все созданные подключения

        /// <summary>
        /// добавление подключенного клиента в список
        /// </summary>
        /// <param name="clientObject">клиент</param>
        public void AddConnection(ClientObject clientObject)
        {
            clients.Add(clientObject);
        }

        /// <summary>
        /// удаление подключенного клиента из списка
        /// </summary>
        /// <param name="id">id клиента</param>
        public void RemoveConnection(string id)
        {
            ClientObject client = clients.FirstOrDefault(c => c.Id == id); // получаем по id закрытое подключение
            if (client != null)
                clients.Remove(client); // и удаляем его из списка подключений
        }

        /// <summary>
        /// ожидание новых подключений
        /// </summary>
        public void Listen()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, 8888); // создание сервера для прослушивание порта
                tcpListener.Start(); // запуск сервера
                Console.WriteLine("Сервер запущен. Ожидание подключений..."); // сервер успешно запущен

                while (true) // в бесконечном цикле ждем новых подключений
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient(); // ждем пока не появится клиент с запросом на подключение

                    ClientObject clientObject = new ClientObject(tcpClient, this); // создание объекта класса ClientObject
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process)); // создание отдельного потока для подключенного клиента
                    clientThread.Start(); // запуск потока
                }
            }
            catch (Exception ex) // в случае ошибки
            {
                Console.WriteLine(ex.Message); // выводим ошибку на экран
                Disconnect(); // выключаем сервер
            }
        }

        /// <summary>
        /// отправление сообщения всем клиентам кроме того кто отправил сообщение
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <param name="id">id клиента который отправил сообщение</param>
        public void BroadcastMessageEveryone(string message, string id)
        {
            byte[] data = Encoding.Unicode.GetBytes(message); // перевод сообщения в байты
            for (int i = 0; i < clients.Count; i++) // отправляем сообщение всем клиентам
                if (clients[i].Id != id) // если id клиента не равно id отправляющего
                    clients[i].Stream.Write(data, 0, data.Length); //передача данных
        }

        /// <summary>
        /// отправляем сообщение клиенту который отправил сообщение
        /// </summary>
        /// <param name="message">сообщение</param>
        /// <param name="id">id клиента который отправил сообщение</param>
        public void BroadcastMessageOnlyone(string message, string id)
        {
            byte[] data = Encoding.Unicode.GetBytes(message); // перевод сообщение в байты
            for (int i = 0; i < clients.Count; i++) // отправляем сообщение всем клиентам
                if (clients[i].Id == id) // если id клиента равен id отправляющего
                    clients[i].Stream.Write(data, 0, data.Length); //передача данных
        }

        /// <summary>
        /// останавить сервер и закрыть программу
        /// </summary>
        public void Disconnect()
        {
            tcpListener.Stop(); //остановка сервера

            for (int i = 0; i < clients.Count; i++) // разрываем подключение со всеми клиентами
                clients[i].Close(); //отключение клиента

            Environment.Exit(0); //завершение процесса
        }
    }
}
