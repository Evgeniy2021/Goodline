using System;
using System.Collections.Generic;

namespace post_office
{
    class Program
    {
        static void Main(string[] args)
        {
            int tempPost_time, temp_visitors, temp_time;

            Console.WriteLine("Задайте время работы почты (в минутах): ");
            while (!Int32.TryParse(Console.ReadLine(), out tempPost_time))
                Console.WriteLine("Неверное значение, задайте правильно время работы почты:");

            Console.WriteLine("Задайте количество посетителей, желающих забрать посылку:");
            while (!Int32.TryParse(Console.ReadLine(), out temp_visitors))
                Console.WriteLine("Ошибка, укажите правильно количество посетителей:");
            if (temp_visitors == 0)
                Console.WriteLine("Посетителей нет!");

            Console.WriteLine("Задайте время(в минутах)\nзатрачиваемое для обслуживания\nодного посетителя из очереди:");
            Queue<int> time = new();
            for (int i = 0; i < temp_visitors; i++)
            {
                while (!Int32.TryParse(Console.ReadLine(), out temp_time))
                    Console.WriteLine("Задайте правильно время : ");
                time.Enqueue(temp_time);
                if (tempPost_time > 0)
                {
                    tempPost_time -= time.Dequeue();
                }
            }
            Console.WriteLine("Kоличество посетителей не получивших посылки: {0} ", time.Count);
        }
    }
}