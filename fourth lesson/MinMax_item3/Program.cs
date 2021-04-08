using System;
using System.Linq;
using System.Collections.Generic;

namespace Item_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit, numeral;
            Console.WriteLine("Задайте общее колличество значений\nдля вычисления MIN и MAX: ");
            while (!Int32.TryParse(Console.ReadLine(), out limit) || limit < 2)
                Console.WriteLine("Задайте целое число:\n(от 2х и более)");
            Console.WriteLine("\nВведите значения:");
            List<int> listNumb = new(limit);
            for (int i = 0; i < limit; i++)
            {
                while (!Int32.TryParse(Console.ReadLine(), out numeral))
                    Console.WriteLine("Нужно ввести целое число: ");
                listNumb.Add(numeral);
            }
            var sortedNum = listNumb.OrderBy(listNumb => listNumb);
            if (sortedNum.Last() > sortedNum.First())
                Console.WriteLine("\nЭлемент списка: Min: {0}\tMax: {1}", sortedNum.First(), sortedNum.Last());
            else
                Console.WriteLine("\nЗначения все равны");
            Console.ReadKey();
        }
    }
}
