using System;

namespace ConsoleApp1
{
    class CodeFile_1_1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число месяца");
            bool i;
            do
            {
                int num = int.Parse(Console.ReadLine());
                i = true;
                if (num >= 1 && num <= 12)
                {
                    switch (num)
                    {
                        case 1: Console.WriteLine("Январь"); break;
                        case 2: Console.WriteLine("Феврал"); break;
                        case 3: Console.WriteLine("Март"); break;
                        case 4: Console.WriteLine("Апрель"); break;
                        case 5: Console.WriteLine("Май"); break;
                        case 6: Console.WriteLine("Июнь"); break;
                        case 7: Console.WriteLine("Июль"); break;
                        case 8: Console.WriteLine("Август"); break;
                        case 9: Console.WriteLine("Сентябрь"); break;
                        case 10: Console.WriteLine("Октябрь"); break;
                        case 11: Console.WriteLine("Ноябрь"); break;
                        case 12: Console.WriteLine("Декабрь"); break;
                    }
                }
                else
                {
                    i = false;
                    Console.WriteLine("Вы ошиблись при вводе числа");
                }
            } while (i == false);
            Console.ReadKey();
        }
    }
}
