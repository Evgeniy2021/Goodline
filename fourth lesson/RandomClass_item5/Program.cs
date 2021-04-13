using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Random value = new Random();
            List<int> chaos = new();
            for (int i = 0; i < 50; i++)
            {
                chaos.Add(value.Next(0, 26));
                /*foreach (int RandVal in chaos)
                {
                    Console.Write(RandVal + " ");
                }*/
            }
            //Console.WriteLine("\n");
            IEnumerable<int> temp_val = chaos.Where(num => num >= 10 && num <= 20).Distinct();
            var sortVal = temp_val.OrderByDescending(val => val);
            foreach (int upshot in sortVal)
            {
                Console.Write(upshot + " ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
