using System;
using System.Collections.Generic;
using System.Linq;

namespace eSport
{
    class Team
    {
        //DisplayAllTeam(1)
        public static void DisplayTeam(Dictionary<string, int> all_team)//вывод полного списка команд
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
    }
    class TmPlayer
    {
        public string Name { get; set; }
        public string ClanName { get; set; }
        public int OfWins { get; set; }
        public int Level { get; set; }
        public List<string> Status { get; set; }//звание игрока (участник, старейшина , соруководитель, глава)
        public TmPlayer()
        {
            Status = new List<string>();
        }
    }
    class Program
    {
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
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                        break;
                }
                catch (KeyNotFoundException) //перейдите к выбору действия.
                {
                    Console.WriteLine("Указанной команды \"{0}\" нет в списке.", teamName);
                    Console.WriteLine("Попробутй ещё раз, или для выхода в меню нажмите 'Esc'");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                        break;
                }
            } while (!victory.ContainsKey(teamName) || Console.ReadKey().Key != ConsoleKey.Escape);
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
            while (vic < 0)
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
                while (del_team.Trim() == "" || Console.ReadKey().Key == ConsoleKey.Home)
                {
                    Console.Write("Укажите имя команды: ");
                    del_team = Console.ReadLine();
                    // if (Console.ReadKey().Key == ConsoleKey.Home)
                }
                if (!remove_team.ContainsKey(del_team))
                {
                    Console.WriteLine("Имя команды не найдено, попробуйте ещё раз. Для выхода в меню нажмите 'Home'");
                    if (Console.ReadKey().Key == ConsoleKey.Home)
                        break;
                    else
                        continue;
                }
                else
                {
                    remove_team.Remove(del_team);
                    Console.WriteLine("Команда удалена из списка.");
                    Console.WriteLine("\nУдалить другую команду, или для прехода в меню нажмите 'Home'.");
                    if (Console.ReadKey().Key == ConsoleKey.Home)
                        break;
                    continue;
                }
            } while (Console.ReadKey().Key != ConsoleKey.Home);
        }
        static public void TournamentStage(Dictionary<string, int> tournament_team)// Этапы турнира
        {
            Console.Clear();
            Console.WriteLine("Команды прошедшие во второй тур\n");
            var TeamVictory = tournament_team.Where((team, index) => team.Value > 25);
            foreach (var teamSt in TeamVictory)
            {
                Console.WriteLine(teamSt); // команды "второго" этапа
            }
            Console.WriteLine("Команды прошедшие в первый тур\n");

            Console.WriteLine("Призовые места заняли финалисты\n");

            Console.WriteLine("\nДля прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }
        //StarVictory(6)
        static public void StarVictory(Dictionary<string, int> stars_team)// Звёзды за победы
        {
            Console.Clear();
            Console.WriteLine("Звёздный статус команд (1 звезда за 10 побед): \n");
            foreach (KeyValuePair<string, int> numStar in stars_team.Select(numStar => new KeyValuePair<string, int>(numStar.Key, numStar.Value / 10)))
            {
                Console.WriteLine($"{numStar.Key,-10}" + numStar.Value);
            }
            Console.WriteLine("\nДля прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }
        //StarVictory(7)
        static public void FinalistsFirst(Dictionary<string, int> contender)// Претенденты в финал
        {
            Console.Clear();
            Console.WriteLine("Колличество претендентов в финал (команды у которых более 30 побед): \n");
            int numEven = contender.Aggregate(0, (count, TeVal) => TeVal.Value >= 30 ? count + 1 : count);
            Console.WriteLine("Всего команд: " + numEven);
            Console.WriteLine("\nДля прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }
        static void Main()
        {
            Menu.Beginning();
        }
    }
}

