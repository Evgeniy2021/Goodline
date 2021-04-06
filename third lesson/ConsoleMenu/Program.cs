using System;
using System.Collections.Generic;

namespace ConsoleMenu
{
    class Program
    {
        static public string[] MenuStrings =
           {
            "1 - Вывод списка всех форматов файлов и их описания",
            "2 - Вывод описания указанного формата файла",
            "3 - Добавление нового формата файла и его описания",
            "4 - Удаление указанного формата файла",
            "5 - Выход"
        };
        static public void DisplayMenu()
        {
            Console.Clear();
            foreach (var menuString in MenuStrings)
            {
                Console.WriteLine(menuString);
            }
            Console.WriteLine("Нажмите цифру, соответствующую номеру меню.");
        }
        //DisplayAll(1)
        static public void DisplayDictionary(Dictionary<string, string> all_content)//вывод полного списка с обоими значениями
        {
            Console.Clear();
            if (all_content.Count == 0)
            {
                Console.WriteLine("Список пуст.");
            }
            else
            {
                foreach (KeyValuePair<string, string> all in all_content)
                {
                    Console.WriteLine("Формат {0}, это {1}", all.Key, all.Value);
                }
            }
            Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }
        //DescriptionTyp(2)
        static public void DescriptionFile(Dictionary<string, string> typ_file)//вывод названия по короткому описанию
        {
            Console.Clear();
            Console.WriteLine("\nВведите формат файла для отображения его описания");  //1. 
            string format;
            do                                                                         //2. 
            {
                format = Console.ReadLine();
                try
                {
                    Console.WriteLine("\"{1}\" - {0}.", typ_file[format], format);//формат-описание+
                    Console.WriteLine("посмотреть другой формат, или для выхода в меню нажмите 'Esc'");
                }
                catch (KeyNotFoundException) //перейдите к выбору действия.
                {
                    Console.WriteLine("Указанного формата \"{0}\" нет в списке.", format);
                    Console.WriteLine("Попробутй ещё раз, или для выхода в меню нажмите 'Esc'");

                }
            } while (typ_file.ContainsKey(format) | Console.ReadKey().Key != ConsoleKey.Escape);
            Console.WriteLine("\nДля прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }
        //AttachTyp(3)
        static public void AttachTypFile(Dictionary<string, string> attach_typ)// Добавление нового формата и описания
        {
            Console.Clear();
            Console.WriteLine("Введите формата файла для его добавления в список");
            string new_format = Console.ReadLine();
            while (new_format.Trim() == "")
            {
                Console.Write("Попробуйте снова ввести формат файла: ");
                new_format = Console.ReadLine();
            }
            Console.WriteLine("Введите описание формата файла для его добавления в список");
            string description = Console.ReadLine();
            while (description.Trim() == "")
            {
                Console.Write("Попробуйте снова ввести имя: ");
                description = Console.ReadLine();
            }
            if (!attach_typ.ContainsKey(new_format))
            {
                attach_typ.Add(new_format, description);
                Console.WriteLine("Введённый вами формат \"{0}\" и его описание успешно добавлены в список.", new_format);
            }
            Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }
        //RemoveTyp(4)
        static public void RemoveTypFile(Dictionary<string, string> remove_typ)// Удаление формата и описания
        {
            Console.Clear();
            Console.WriteLine("Введите формата файла для его удаления из списка");
            string del_format = Console.ReadLine();
            while (del_format.Trim() == "")
            {
                Console.Write("Попробуйте снова ввести формат: ");
                del_format = Console.ReadLine();
            }
            // Console.WriteLine("\nУдалить формат \"{0}\" ", Console.ReadLine());
            if (!remove_typ.ContainsKey(del_format))
            {
                Console.WriteLine("Формат файла не найден.");
            }
            else
            {
                remove_typ.Remove(del_format);
                Console.WriteLine("Формат файла и его описание удалены.");
            }
        }
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
            ConsoleKey key = ConsoleKey.Enter;
            do
            {
                DisplayMenu();
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        DisplayDictionary(file_format);
                        break;
                    case ConsoleKey.D2:
                        DescriptionFile(file_format);
                        break;
                    case ConsoleKey.D3:
                        AttachTypFile(file_format);
                        break;
                    case ConsoleKey.D4:
                        RemoveTypFile(file_format);
                        break;
                    default: continue;
                }
            } while (key != ConsoleKey.D5);
            Console.Clear();
            Console.WriteLine("Пока!");
        }
    }
}
