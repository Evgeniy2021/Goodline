using System;
using System.Collections.Generic;
using System.Linq;

namespace eSport
{
    public class Team
    {
        public string TeamName { get; set; }
        public int Wins { get; set; }
        public int Stars { get; set; }
        public List<Player> Players { get; set; }
        public Team()
        {
            this.TeamName = "Имя";
            this.Wins = 0;
            this.Stars = 0;
            this.Players = new List<Player>();
        }
        public Team(string TeamName, int Wins, int Stars, List<Player> Players)
        {
            this.TeamName = TeamName;
            this.Wins = Wins;
            this.Stars = Stars;
            this.Players = Players;
        }
        public override string ToString()
        {
            string temp = $"{TeamName} {Wins} {Stars}\n";
            foreach (var player in Players)
                temp += "\n" + player;
            return temp + "\n";//{TeamName,-10} |   {Wins,-3} |  {Stars,-3} |\n{"|",12} {"|",7} {"|",6}";
        }
        //DisplayAllTeam(1)
        public static void DisplayTeam(List<Team> Teams)//вывод полного списка команд
        {
            Console.Clear();
            if (Teams.Count == 0)
            {
                Console.WriteLine("Список пуст.");
            }
            else
            {
                //Console.WriteLine("|");
                foreach (Team all in Teams)
                {
                    Console.WriteLine(all);
                }
            }
            Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }
        //Victory(2)
        static public void Victory(List<Team> Teams)// колличества побед указанной команды
        {
            Console.Clear();
            Console.WriteLine("\nВпишите имя команды для просмотра их побед");
            string teamName;
            do
            {
                //Team team;
                teamName = Console.ReadLine();
                // if (Teams.Where(t => t.TeamName == teamName).Count() > 0)
                Team team = Program.Teams.Where(t => t.TeamName == teamName).ToList().First();
                try
                {
                    //Console.Clear();
                    Console.WriteLine("Команда \"{0}\" - {1} побед.", team.TeamName, team.Wins);//команда-победа
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
            } while ((Teams.Where(t => t.TeamName == teamName).Count() == 0) || Console.ReadKey().Key == ConsoleKey.Escape);
        }
        //Attachteam(3)
        static public void AttachTeam(List<Team> Teams)// Добавление команды
        {
            Console.Clear();
            //Team NEWTeam = new Team(TeamName, Wins, Stars, Players);   -

            Console.WriteLine("Введите имя новой команды для её добавления в список");
            string new_team = Console.ReadLine();
            while (new_team.Trim() == "")
            {
                Console.Write("Попробуйте снова: ");
                new_team = Console.ReadLine();
            }
            Console.WriteLine("Введите колличество побед команды для добавления в список");
            /* Program.Teams.Add(new Team [new_team], 5, 10, new List<Player>()
             {
                 new Player("Алексей", 2, Player.PlayerStatus.Участник),
                 new Player("Серж", 2,Player.PlayerStatus.Глава),
                 new Player("Жека", 2, Player.PlayerStatus.Соруководитель),
                 new Player("Александр", 2, Player.PlayerStatus.Старейшина),
                 new Player("Антон", 2, Player.PlayerStatus.Соруководитель ),
             }));*/
            // int vic = int.Parse(Console.ReadLine());
            // while (vic < 0)
            // {
            // Console.Write("Попробуйте снова: ");
            // vic = int.Parse(Console.ReadLine());
            // }
            // if (!Teams.Contains(Teams))
            // {
            // attach_team.Add(new_team, vic);
            // Console.WriteLine("Команда \"{0}\" и её победы успешно добавлены в список.", new_team);
            // }
            // Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
            // Console.ReadKey();
        }
        //Removeteam(4)
        static public void RemoveTeam(List<Team> Teams)// Удаление команды
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
                if (!Teams.Contains((Team)Teams.Where(t => t.TeamName == del_team)))
                {
                    Console.WriteLine("Имя команды не найдено, попробуйте ещё раз. Для выхода в меню нажмите 'Home'");
                    if (Console.ReadKey().Key == ConsoleKey.Home)
                        break;
                    else
                        continue;
                }
                else
                {
                    Teams.Remove((Team)Teams.Where(t => t.TeamName == del_team));
                    Console.WriteLine("Команда удалена из списка.");
                    Console.WriteLine("\nУдалить другую команду, или для прехода в меню нажмите 'Home'.");
                    if (Console.ReadKey().Key == ConsoleKey.Home)
                        break;
                    continue;
                }
            } while (Console.ReadKey().Key != ConsoleKey.Home);
        }
        //Tournament(5)--------------------------------------------------------------------------------------
        static public void Tournament(List<Team> Teams)// турнир(сетка)
        {
            Console.Clear();
            Console.WriteLine("Участники турнира:\n");
            Console.WriteLine($" {"Команды",-10} | {"Победы"}");
            Console.WriteLine($" {"-----------|--------"}");
            foreach (var team in Teams)
            {
                team.Wins = 0;
                if (Teams.Count == 0)
                {
                    Console.WriteLine("Список пуст.");
                }
                else
                {
                    Console.WriteLine($"  {team.TeamName,-10}|   {team.Wins}{" ",-13}");
                    if (Teams.IndexOf(team) % 2 != 0)
                        Console.WriteLine($" {"-----------",-10}|--------");
                }
            }
            Console.WriteLine("\nПервый тур\n");//------------------------------1----------------------------
            //List<Team> Teams2tour = new List<Team>();
            Console.WriteLine($" {"Команды",-10} | {"Победы"}");
            Console.WriteLine($" {"-----------|--------"}");
            Random WinsTeam = new Random();
            List<Team> Teams2tour = Teams;
            for (int i = 0; i < 2; i++)
            {
               
            }
                foreach (var team in Teams2tour)
            {
               // team.Wins = 0;
                if (Teams.Count == 0)
                {
                    Console.WriteLine("Список пуст.");
                }
                else
                {
                    Console.WriteLine($"  {team.TeamName,-10}|   {team.Wins}{" ",-13}");
                    if (Teams.IndexOf(team) % 2 != 0)
                        Console.WriteLine($" {"-----------",-10}|--------");
                }
            }
                Console.WriteLine("Второй тур\n");

            Console.WriteLine("Третий тур\n");

            Console.WriteLine("Победитель!!!\n");

            Console.WriteLine("\nДля прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }
        //StarVictory(6)-------------------------------------------------------------------------------------
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
        //StarWin(7)
        static public void FinalistsFirst(Dictionary<string, int> contender)// Претенденты в финал
        {
            Console.Clear();
            Console.WriteLine("Колличество претендентов в финал (команды у которых более 30 побед): \n");
            int numEven = contender.Aggregate(0, (count, TeVal) => TeVal.Value >= 30 ? count + 1 : count);
            Console.WriteLine("Всего команд: " + numEven);
            Console.WriteLine("\nДля прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
