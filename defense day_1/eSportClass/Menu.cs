using System;
using System.Collections.Generic;

namespace eSport
{
    static public class Menu
    {
        static public string[] MenuStrings =
             {
            "1 - Вывод списка всех команд с колличеством побед в играх",
            "2 - Вывод колличества побед указанной команды",
            "3 - Добавление новой команды с их победами",
            "4 - Удаление команды из списка",
            "5 - Турнирная сетка игр",
            "6 - Звёздный статус",
            "7 - Претенденты на финал",
            "8 - Выход"
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
        static public void Beginning()
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
                DisplayMenu();
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        Team.DisplayTeam(team_name);
                        break;
                    case ConsoleKey.D2:
                        Team.Victory(team_name);
                        break;
                    case ConsoleKey.D3:
                        Team.AttachTeam(team_name);
                        break;
                    case ConsoleKey.D4:
                        Team.RemoveTeam(team_name);
                        break;
                    case ConsoleKey.D5:
                        Team.TournamentStage(team_name);
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
            Console.Clear();
            Console.WriteLine("До встречи!");
        }
    }
}
