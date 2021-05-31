using System;
using System.Collections.Generic;
using System.Linq;

namespace WinForms_eSport
{
    public class Team
    {
        public string TeamName { get; set; }
        public int Wins { get; set; }
        public int Stars { get; set; }
        public List<Player> Players { get; set; }
        public Team()
        {
            TeamName = "Без имени";
            Wins = 0;
            Stars = 0;
            Players = new List<Player>();
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
            string temp = $"Команда {TeamName}! - Одержано побед:{Wins}! - Боевых звёзд завоёвано:{Stars}!\n";
            foreach (var player in Players)
                temp += "\n" + player;
            return temp + "\n";
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
                Team team = Model.Teams.Where(t => t.TeamName == teamName).ToList().First();
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
            } while (Teams.Where(t => t.TeamName == teamName).Count() == 0 || Console.ReadKey().Key == ConsoleKey.Escape);
        }
        //Attachteam(3)
        static public void AttachTeam(List<Team> Teams)// Добавление команды
        {
            Console.Clear();
            do
            {
                List<Player> tPlayers = new List<Player>();
                int ntWins, ntStars, npStars, st = 4;
                Console.WriteLine("Введите имя новой команды для её добавления в список");
                string new_team = Console.ReadLine();
                while (new_team.Trim() == "")
                {
                    Console.Write("Попробуйте снова: ");
                    new_team = Console.ReadLine();
                }
                if (Model.Teams.Any(t => t.TeamName == new_team))
                {
                    Console.WriteLine("Такая команда уже есть, попробуйте ещё раз. Для выхода в меню нажмите 'Home'");
                    if (Console.ReadKey().Key == ConsoleKey.Home)
                        break;
                }
                else
                {
                    Console.WriteLine(" Количество побед");
                    while (!int.TryParse(Console.ReadLine(), out ntWins))
                        Console.WriteLine("Ошибка, введите количество побед числом!");
                    Console.WriteLine(" Количество звёзд");
                    while (!int.TryParse(Console.ReadLine(), out ntStars))
                        Console.WriteLine("Ошибка, введите количество звёзд числом!");
                    Console.WriteLine("Введите состав команды(5-ть игроков)\n в порядке:" +
                        " Имя игрока, звёзды, статус(цифрой)\n1-Глава\n2-Соруководитель\n3-Старейшина\n4-Участник\n ");
                    for (int i = 1; i < 6; i++)
                    {
                        Console.WriteLine($"Имя {i} игрока ");
                        string nPlayer = Console.ReadLine();
                        Console.WriteLine("Количество звёзд у игрока!");
                        while (!int.TryParse(Console.ReadLine(), out npStars))
                            Console.WriteLine("Ошибка, введите число!");
                        Console.WriteLine("Статус игрока(цифрой)");
                        while (!int.TryParse(Console.ReadLine(), out st) && st >= 0 && st <= 3)
                            Console.WriteLine("Ошибка, введите число!");
                        tPlayers.Add(new Player(nPlayer, npStars, (Player.PlayerStatus)st));
                    }
                    Model.Teams.Add(new Team(new_team, ntWins, ntStars, tPlayers));
                    Console.WriteLine("Команда добавлена. Для выхода в меню нажмите 'Home'");
                    if (Console.ReadKey().Key == ConsoleKey.Home)
                        break;
                    else
                        continue;
                }
            } while (Console.ReadKey().Key != ConsoleKey.Home);
        }
        //Removeteam(4)
        static public void RemoveTeam(List<Team> Teams)// Удаление команды
        {
            Console.Clear();
            Console.WriteLine("Введите имя команды для её удаления из списка");
            do
            {
                string del_team = Console.ReadLine();
                while (del_team.Trim() == "")
                {
                    Console.Write("Укажите имя команды  или для выхода в 'Меню' ещё раз нажмите 'Enter': ");
                    if (Console.ReadLine().Trim() == "")
                        return;
                }
                if (!Model.Teams.Any(t => t.TeamName == del_team))
                {
                    Console.WriteLine("Имя команды не найдено, попробуйте ещё раз. Для выхода в меню нажмите 'Enter' ");
                    // del_team = Console.ReadLine();
                    if (del_team.Trim() == "")
                        return;
                }
                else
                {
                    Model.Teams.Remove(Teams.Find(t => t.TeamName.Contains(del_team)));
                    Console.WriteLine("Команда удалена из списка.");
                    Console.WriteLine("\nУдалить другую команду, или для прехода в меню нажмите 'Enter'.");
                }
            } while (Console.ReadLine().Trim() == "");
        }
        //Tournament(5)--------------------------------------------------------------------------------------
        static public void Tournament(List<Team> Teams)// турнир(сетка)
        {
            Console.Clear();
            if (Teams.Count() != 8)
            {
                Console.WriteLine("Для проведения турнира нужно 8 команд!");
                Console.WriteLine($" В списке {Teams.Count} команд.");
                Console.WriteLine($"Нажмите любую клавишу.");
                Console.ReadKey();
                return;
            }
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
            Console.WriteLine("Для перехода к первому туру, нажмите любую клавишу.");
            Console.ReadKey();
            Console.Clear();
            Random RandomWins = new Random();
            List<Team> TourTeams = new List<Team>();
            foreach (var team in Teams)
            {
                TourTeams.Add(team);
            }
            Console.WriteLine("\nПервый тур\n");//------------------------------1----------------------------
            Console.WriteLine($" {"Команды",-10} | {"Победы"}");
            Console.WriteLine($" {"-----------|--------"}");
            foreach (var team in TourTeams)
            {
                team.Wins = RandomWins.Next(0, 5);
                // Console.WriteLine($"  {team.TeamName,-10}|   {team.Wins}{" ",-13}");
                if (TourTeams.IndexOf(team) % 2 != 0 && TourTeams[TourTeams.IndexOf(team) - 1].Wins == team.Wins)
                {
                    team.Wins++;
                }
                Console.WriteLine($"  {team.TeamName,-10}|   {team.Wins}{" ",-13}");
                if (TourTeams.IndexOf(team) % 2 != 0)
                    Console.WriteLine($" {"-----------",-10}|--------");
            }
            Console.WriteLine("Для перехода ко второму туру, нажмите любую клавишу.");
            Console.ReadKey();
            Console.Clear();
            for (int i = TourTeams.Count - 1; i > 0; i -= 2)
            {
                if (TourTeams[i].Wins > TourTeams[i - 1].Wins)
                    TourTeams.Remove(TourTeams[i - 1]);
                else
                    TourTeams.Remove(TourTeams[i]);
            }
            Console.WriteLine("Второй тур\n");//--------------------------------2----------------------------
            Console.WriteLine($" {"Команды",-10} | {"Победы"}");
            Console.WriteLine($" {"-----------|--------"}");
            foreach (var team in TourTeams)
            {
                team.Wins = RandomWins.Next(0, 5);
                // Console.WriteLine($"  {team.TeamName,-10}|   {team.Wins}{" ",-13}");
                if (TourTeams.IndexOf(team) % 2 != 0 && TourTeams[TourTeams.IndexOf(team) - 1].Wins == team.Wins)
                {
                    team.Wins++;
                }
                Console.WriteLine($"  {team.TeamName,-10}|   {team.Wins}{" ",-13}");
                if (TourTeams.IndexOf(team) % 2 != 0)
                    Console.WriteLine($" {"-----------",-10}|--------");
            }
            Console.WriteLine("Для перехода к третьему туру, нажмите любую клавишу.");
            Console.ReadKey();
            Console.Clear();
            for (int i = TourTeams.Count - 1; i > 0; i -= 2)
            {
                if (TourTeams[i].Wins > TourTeams[i - 1].Wins)
                    TourTeams.Remove(TourTeams[i - 1]);
                else
                    TourTeams.Remove(TourTeams[i]);
            }
            Console.WriteLine("Третий тур\n");//--------------------------------3----------------------------
            Console.WriteLine($" {"Команды",-10} | {"Победы"}");
            Console.WriteLine($" {"-----------|--------"}");
            foreach (var team in TourTeams)
            {
                team.Wins = RandomWins.Next(0, 5);
                // Console.WriteLine($"  {team.TeamName,-10}|   {team.Wins}{" ",-13}");
                if (TourTeams.IndexOf(team) % 2 != 0 && TourTeams[TourTeams.IndexOf(team) - 1].Wins == team.Wins)
                {
                    team.Wins++;
                }
                Console.WriteLine($"  {team.TeamName,-10}|   {team.Wins}{" ",-13}");
                if (TourTeams.IndexOf(team) % 2 != 0)
                    Console.WriteLine($" {"-----------",-10}|--------");
            }
            Console.WriteLine("Для перехода в финал, нажмите любую клавишу.");
            Console.ReadKey();
            Console.Clear();
            for (int i = TourTeams.Count - 1; i > 0; i -= 2)
            {
                if (TourTeams[i].Wins > TourTeams[i - 1].Wins)
                    TourTeams.Remove(TourTeams[i - 1]);
                else
                    TourTeams.Remove(TourTeams[i]);
            }
            Console.WriteLine("Победитель!!!\n");//-----------------------------V----------------------------
            foreach (var team in TourTeams)
            {
                team.Wins = RandomWins.Next(0, 5);
                // Console.WriteLine($"  {team.TeamName,-10}|   {team.Wins}{" ",-13}");
                if (TourTeams.IndexOf(team) % 2 != 0 && TourTeams[TourTeams.IndexOf(team) - 1].Wins == team.Wins)
                {
                    team.Wins++;
                }
                if (TourTeams.IndexOf(team) % 2 == 0)
                    Console.WriteLine(team);
            }
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
