using System;

namespace symmetric_diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            bool symmetric = true;
            Console.Write("укажите размерность массива: ");
            int size = int.Parse(Console.ReadLine());
            int[,] array = new int[size, size];
            Console.WriteLine("Введите значения");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    array[i, j] = int.Parse(Console.ReadLine());
                }
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = i + 1; j < array.GetLength(1) - i; j++)
                {
                    if (array[i, j] != array[j, i])
                        symmetric = false;
                }
            }
            if (symmetric == true)
                Console.WriteLine("Диагональ массива симметрична!");
            else Console.WriteLine("Диагональ массива не симметрична!");
            Console.ReadLine();
            //Сложность алгоритма: O(n2) — квадратичная сложность
        }
    }
}
