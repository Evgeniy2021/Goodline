using System;
using System.Collections.Generic;

namespace ConsoleMenu
{
    class Program
    {
        static public string[] MenuStrings =
           {
            "1 - Вывод списка",
            "2 - Добавление элемента",
            "3 - Поиск элемента по номеру",
            "4 - Выход"
        };
        static void Main(string[] args)
        {

            Dictionary<string, string> file_format = new()
            {
                { "dll", "Dynamic Link Library" },
                { "dbf", "Database file" },
                { "mkv", "Matroska Video File" },
                { "gbr", "Gerber File" },
                { "txt", "Raw text file" }
            };
            //вывод полного списка с обоими значениями
            foreach (KeyValuePair<string, string> all in file_format)
            {
                Console.WriteLine("Формат {0}, это {1}", all.Key, all.Value);
            }

            //вывод названия по короткому описанию
            // В случае, если формата не существует, выдайте ошибку и *** перейдите к выбору действия.***
            Console.WriteLine("\nВведите формат файла для отображения его описания");
            string format = Console.ReadLine();
            try
            {
                Console.WriteLine("Формат файла \"{1}\" - {0}.", file_format[format], format);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Указанного формата \"{0}\" нет в списке.", format);
                //*** перейдите к выбору действия.***
            }

            // Добавление нового формата и описания
            Console.WriteLine("Введите формата файла для его добавления в список");
            string new_format = Console.ReadLine();
            Console.WriteLine("Введите описание формата файла для его добавления в список");
            string description = Console.ReadLine();
            if (!file_format.ContainsKey(new_format))
            {
                file_format.Add(new_format, description);
                Console.WriteLine("Введённый вами формат \"{0}\" и его описание успешно добавлены в список.",new_format);
            }

            // Удаление формата и описания
            Console.WriteLine("Введите формата файла для его удаления из списка");
            string del_format = Console.ReadLine();
           // Console.WriteLine("\nУдалить формат \"{0}\" ", Console.ReadLine());
            file_format.Remove(Console.ReadLine());

            if (!file_format.ContainsKey(del_format))
            {
                Console.WriteLine("Key  is not found.");
            }

        }
    }
}
