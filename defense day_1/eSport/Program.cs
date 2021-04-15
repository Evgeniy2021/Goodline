using System;
using System.Collections.Generic;
using System.Linq;

namespace eSport
{

    class Program
    {
        static public string[] MenuStrings =
           {
            "1 - Вывод списка всех команд с колличеством побед в играх",
            "2 - Вывод колличества побед указанной команды",
            "3 - Добавление новой команды с их победами",
            "4 - Удаление команды из списка",
            "5 - Турнирная сетка игр",
            "6 - Выход"
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
        //DisplayAllTeam(1)
        static public void DisplayTeam(Dictionary<string, int> all_team)//вывод полного списка команд
        {
            Console.Clear();
            if (all_team.Count == 0)
            {
                Console.WriteLine("Список пуст.");
            }
            else
            {
                foreach (KeyValuePair<string, int> all in all_team)
                {
                    Console.WriteLine("Команда {0},{1} побед", all.Key, all.Value);
                }
            }

            Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }
        //Victory(2)
        static public void Victory(Dictionary<string, int> victory)// колличества побед указанной команды
        {
            Console.Clear();
            Console.WriteLine("\nВпишите имя команды для просмотра их побед");
            string teamName;
            do
            {
                teamName = Console.ReadLine();
                try
                {
                    Console.WriteLine("\"{1}\" - {0} побед.", victory[teamName], teamName);//команда-победа
                    Console.WriteLine("посмотреть другую команду, или для выхода в меню нажмите 'Esc'");
                }
                catch (KeyNotFoundException) //перейдите к выбору действия.
                {
                    Console.WriteLine("Указанной команды \"{0}\" нет в списке.", teamName);
                    Console.WriteLine("Попробутй ещё раз, или для выхода в меню нажмите 'Esc'");
                }
            } while (!victory.ContainsKey(teamName) || Console.ReadKey().Key != ConsoleKey.Escape);
            //Console.WriteLine("\nДля прехода в меню нажмите любую клавишу...");
            //Console.ReadKey();
        }
        //Attachteam(3)
        static public void AttachTeam(Dictionary<string, int> attach_team)// Добавление команды
        {
            Console.Clear();
            Console.WriteLine("Введите имя новой команды для её добавления в список");
            string new_team = Console.ReadLine();
            while (new_team.Trim() == "")
            {
                Console.Write("Попробуйте снова: ");
                new_team = Console.ReadLine();
            }
            Console.WriteLine("Введите колличество побед команды для добавления в список");
            int vic = int.Parse(Console.ReadLine());
            while (vic >= 0)
            {
                Console.Write("Попробуйте снова: ");
                vic = int.Parse(Console.ReadLine());
            }
            if (!attach_team.ContainsKey(new_team))
            {
                attach_team.Add(new_team, vic);
                Console.WriteLine("Команда \"{0}\" и её победы успешно добавлены в список.", new_team);
            }
            Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }
        //Removeteam(4)
        static public void RemoveTeam(Dictionary<string, int> remove_team)// Удаление команды
        {
            Console.Clear();
            Console.WriteLine("Введите имя команды для её удаления из списка");
            do
            {
                string del_team = Console.ReadLine();
                while (del_team.Trim() == "")
                {
                    Console.Write("Укажите имя команды: ");
                    del_team = Console.ReadLine();
                }
                if (!remove_team.ContainsKey(del_team))
                {
                    Console.WriteLine("Имя команды не найдено, попробуйте ещё раз. Для выхода в меню нажмите 'Home'");
                }
                else
                {
                    remove_team.Remove(del_team);//+++
                    Console.WriteLine("Команда удалена из списка.");
                    Console.WriteLine("\nУдалить другую команду, или для прехода в меню нажмите 'Home'.");
                }
            } while (Console.ReadKey().Key != ConsoleKey.Home);
            // Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
            // Console.ReadKey();
        }
        /*game_grid(5) 
        static public void GameGrid(Dictionary<string, string> grid_team)//сетка игр
        {
            Console.Clear();

            foreach (KeyValuePair<string, string> grid in grid_team)
            {
                Console.SetCursorPosition(Console.WindowWidth / 3, Console.WindowHeight / 2);
                Console.WriteLine("Команда {0}", grid.Key);
                Console.WindowHeight += 2;
            }
            Console.WindowHeight -= 7;
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.WriteLine("        " + Console.WindowWidth);
            Console.WindowHeight -= 2;
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.WriteLine("________ " + Console.WindowHeight);
            //Console.WriteLine("\nДля прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }*/
        static public void TournamentStage(Dictionary<string, int> tournament_team)// Этапы турнира
        {
            Console.Clear();
            Console.WriteLine("Команды прошедшие во второй тур\n");
            var TeamVic = tournament_team.Where((team, index) => team.Value > 25);
            foreach (var teamSt in TeamVic)
                Console.WriteLine(teamSt); // команды "второго" этапа
            Console.WriteLine("\nДля прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }
        static void Main(string[] args)
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
                        DisplayTeam(team_name);
                        break;
                    case ConsoleKey.D2:
                        Victory(team_name);
                        break;
                    case ConsoleKey.D3:
                        AttachTeam(team_name);
                        break;
                    case ConsoleKey.D4:
                        RemoveTeam(team_name);
                        break;
                    case ConsoleKey.D5:
                        TournamentStage(team_name);
                        break;
                    default: continue;
                }
            } while (key != ConsoleKey.D6);
            Console.Clear();
            Console.WriteLine("До встречи!");
        }
    }
}


