using System;
using System.Collections.Generic;
using System.Linq;

namespace DistinctCount_item4
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers, num;
            Console.WriteLine("Задайте общее колличество значений: ");
            while (!Int32.TryParse(Console.ReadLine(), out numbers))
                Console.WriteLine("Задайте целое число!");
            Console.WriteLine("\nВведите значения:");
            List<int> listNumb = new(numbers);
            for (int i = 0; i < numbers; i++)
            {
                while (!Int32.TryParse(Console.ReadLine(), out num))
                    Console.WriteLine("Введите целое число: ");
                listNumb.Add(num);
            }
            // Count<TSource>(IEnumerable<TSource>, Func<TSource, Boolean>)
            int disCount = Enumerable.Count<int>(listNumb.Distinct());
            Console.WriteLine("\nКолличество разных чисел: {0}", disCount);
            Console.ReadKey();
        }
    }
}
