using System;

namespace Second_task
{
    class CodeFile_1_2
    {
        static void Main(string[] args)
        {
            int x = 0, y = 0;
            string way;
            Console.WriteLine("Введите несколько направлени буквами: 'C'- север, 'Ю' -юг, 'В' - восток, 'З' - запад");
            bool check, letter;
            do
            {
                check = true;
                letter = true;
                way = Console.ReadLine().ToLower();
                if (way.Length > 10)
                    Console.WriteLine("Можно ввести не более 10 направлений или меньше\nпопробуйте ещё раз");
                for (int i = 0; i < way.Length; i++)
                {
                    if (way[i] >= 'a' && way[i] <= 'z')
                        check = false;
                    if (way[i] == 'с' | way[i] == 'ю' | way[i] == 'в' | way[i] == 'з')
                    {
                        switch (way[i])
                        {
                            case 'с': y++; break;
                            case 'ю': y--; break;
                            case 'в': x--; break;
                            case 'з': x++; break;
                        }
                    }
                    else
                    {
                        letter = false;
                        x = 0;
                        y = 0;
                    }
                }
                if (check == false)
                    Console.WriteLine("Используйте русский язык");
                if (letter == false)
                    Console.WriteLine("Вы задали неизвестное направление");
            } while (way.Length > 10 || check == false || letter == false);
            if (((x == 0) | (y == 0)))
                Console.WriteLine("Расстояние между точками {0}", x + y);
            else Console.WriteLine("Расстояние между точками {0}", Math.Round(Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2))));
            Console.ReadKey();
        }
    }
}