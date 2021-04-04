using System;
using System.Collections.Generic;

namespace post_office
{
    class Program
    {
        static void Main(string[] args)
        {
            String postTime, Nvisitors, timeVisit;
            int tempPost_time, temp_visitors, temp_time;
            bool logpostTime, logNvisitors, logtimeVisit;
            Console.WriteLine("Задайте время работы почты (в минутах): ");
            do
            {
                postTime = Console.ReadLine();
                logpostTime = Int32.TryParse(postTime, out tempPost_time);
                if (!logpostTime)
                    Console.WriteLine("Неверное значение, задайте правильно время работы почты:");
            } while (!logpostTime);
            Console.WriteLine("Задайте количество посетителей, желающих забрать посылку:");
            do
            {
                Nvisitors = Console.ReadLine();
                logNvisitors = Int32.TryParse(Nvisitors, out temp_visitors);
                if (!logNvisitors)
                    Console.WriteLine("Ошибка, укажите правильно количество посетителей:");
                else if (temp_visitors == 0)
                    Console.WriteLine("Посетителей нет!");

            } while (!logNvisitors);
            Console.WriteLine("Задайте время(в минутах)\nзатрачиваемое для обслуживания\nодного посетителя из очереди:");
            do
            {
                logtimeVisit = true;
                Queue<int> time = new();
                for (int i = 0; i < temp_visitors; i++)
                {
                    timeVisit = Console.ReadLine();
                    logtimeVisit = Int32.TryParse(timeVisit, out temp_time);
                    if (!logtimeVisit)
                    {
                        Console.WriteLine("Задайте правильно время : ");
                        temp_visitors++;
                    }
                    time.Enqueue(temp_time);
                    if (tempPost_time > 0)
                    {
                        tempPost_time -= time.Peek();
                        time.Dequeue();
                    }
                }
                Console.WriteLine("Kоличество посетителей не получивших посылки: {0} ", time.Count);
            } while (!logtimeVisit);
        }
    }
}


