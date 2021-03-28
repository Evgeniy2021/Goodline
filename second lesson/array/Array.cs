using System;

namespace ArrayNum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("укажите размерность массива: ");
            int arrayLength = int.Parse(Console.ReadLine());
            int[] mainArray = new int[arrayLength];
            Console.WriteLine("Введите элементы массива");
            for (int i = 0; i < arrayLength; i++)
                mainArray[i] = int.Parse(Console.ReadLine());
            Array.Sort(mainArray);
            int count = 1;
            int selectIndex = mainArray[0];
            foreach (int iteratioIndexArray in mainArray)
            {
                if (iteratioIndexArray != selectIndex)
                {
                    count++;
                    selectIndex = iteratioIndexArray;
                }
            }
            Console.WriteLine("Количество различных элементов: " + count);
            Console.ReadKey();
            //Сложность алгоритма: O(n) — линейная сложность
        }
    }
}
