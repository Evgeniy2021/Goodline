using System;
using System.Collections.Generic;

namespace post_office
{
    class Program
    {
        static void Main(string[] args)
        {
            int cTaker = 0;
            Console.WriteLine("Задайте время работы почты (в минутах): ");
            int postTime = int.Parse(Console.ReadLine());
            Console.WriteLine("Задайте количество посетителей, желающих забрать посылку: ");
            int Nvisitors = int.Parse(Console.ReadLine());
            Console.WriteLine("Задайте время(в минутах)\nзатрачиваемое для обслуживания\nодного посетителя из очереди: ");
            List<int> time = new();
            for (int i = 0; i < Nvisitors; i++)
            {
                time.Add(int.Parse(Console.ReadLine()));
                if (postTime > 0)
                {
                    postTime -= time[i];
                    cTaker++;
                }
            }
            time.RemoveRange(0, cTaker);
            Console.WriteLine("Kоличество посетителей не получивших посылки: {0} ", time.Count);
        }
    }
}


