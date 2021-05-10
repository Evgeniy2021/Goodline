using System;
using System.Collections.Generic;

namespace eSport
{
    static public class Menu
    {
        static public string[] Select =
             {
            "1 - Администратор",
            "2 - Пользователь",
            "3 - Выход"
        };
        static public string[] MenuAdmin =
             {
            "1 - Вывод списка всех команд с колличеством побед в играх",
            "2 - Вывод колличества побед указанной команды",
            "3 - Добавление новой команды с их победами",
            "4 - Удаление команды из списка",
            "5 - Проведение турнира игр",
            "6 - Звёздный статус",
            "7 - Претенденты на финал",
            "8 - Назад"
        };
        static public string[] MenuUser =
             {
            "1 - Вывод списка всех команд с колличеством побед в играх",
            "2 - Вывод колличества побед указанной команды",
            "3 - Проведение турнира игр",
            "4 - Назад"
        };
        static public void DisplayStart()
        {
            Console.Clear();
            foreach (var select in Select)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(select);
            }
            Console.WriteLine("Нажмите цифру, соответствующую номеру меню.");
        }
        static public void DisplayMenuA()
        {
            Console.Clear();
            foreach (var admin_menu in MenuAdmin)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(admin_menu);
            }
            Console.WriteLine("Нажмите цифру, соответствующую номеру меню.");
        }
        static public void DisplayMenuU()
        {
            Console.Clear();
            foreach (var user_menu in MenuUser)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(user_menu);
            }
            Console.WriteLine("Нажмите цифру, соответствующую номеру меню.");
        }
        static public void Begin()
        {
            ConsoleKey key = ConsoleKey.Enter;
            do
            {
                DisplayStart();
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        BeginAdmin();
                        break;
                    case ConsoleKey.D2:
                        BeginUser();
                        break;
                    default: continue;
                }
            } while (key != ConsoleKey.D3);

        }
        static public void BeginAdmin()
        {
            Dictionary<string, int> team_name = new()
            {
                { "Лига", 30 },
                { "Ужас", 15 },
                { "HULK", 27 },
                { "RAB", 28 },
                { "Red", 11 },
                { "King", 20 },
                { "Дикие", 19 },
                { "Зубзазуб", 35 },
            };
            ConsoleKey key = ConsoleKey.Enter;
            do
            {
                DisplayMenuA();
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        Team.DisplayTeam(Program.Teams);
                        break;
                    case ConsoleKey.D2:
                        Team.Victory(Program.Teams);
                        break;
                    case ConsoleKey.D3:
                        Team.AttachTeam(Program.Teams);
                        break;
                    case ConsoleKey.D4:
                        Team.RemoveTeam(Program.Teams);
                        break;
                    case ConsoleKey.D5:
                        Team.Tournament(Program.Teams);
                        break;
                    case ConsoleKey.D6:
                        Team.StarVictory(team_name);
                        break;
                    case ConsoleKey.D7:
                        Team.FinalistsFirst(team_name);
                        break;
                    default: continue;
                }
            } while (key != ConsoleKey.D8);
        }
        static public void BeginUser()
        {
            Dictionary<string, int> team_name = new()
            {
                { "Лига", 30 },
                { "Ужас", 15 },
                { "HULK", 27 },
                { "RAB", 28 },
                { "Red", 11 },
                { "King", 20 },
                { "Дикие", 19 },
                { "Зубзазуб", 35 },
            };
            ConsoleKey key = ConsoleKey.Enter;
            do
            {
                DisplayMenuU();
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        Team.DisplayTeam(Program.Teams);
                        break;
                    case ConsoleKey.D2:
                        Team.Victory(Program.Teams);
                        break;
                    case ConsoleKey.D3:
                        Team.Tournament(Program.Teams);
                        break;
                    default: continue;
                }
            } while (key != ConsoleKey.D4);
        }
    }
}
