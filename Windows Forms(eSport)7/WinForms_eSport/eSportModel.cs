using System;
using System.Collections.Generic;

namespace WinForms_eSport
{
    public class eSportModel
    {
        public List<Team> Teams = new List<Team>();
        public eSportModel()
        {
            InitTeams();
            DBeSport.DatabaseLoad(Teams);
        }

        public string GetTeamsInfo()
        {
            string info = "\n";//<<===== Информация о командах =====>>
            foreach (var team in Teams)
            {
                info += team.ToString() + Environment.NewLine;
            }
            return info;
        }

        public void TournamentSetWins(List<Team> teams)
        {
            Random RandomWins = new Random();
            foreach (var team in teams)
            {
                team.Wins = RandomWins.Next(0, 5);
                if (teams.IndexOf(team) % 2 != 0 && teams[teams.IndexOf(team) - 1].Wins == team.Wins)
                {
                    team.Wins++;
                }
            }
        }
        public List<Team> TournamentGetWinTeams(List<Team> teams)
        {
            List<Team> winers = new List<Team>();
            for (int i = 0; i < teams.Count; i += 2)
            {
                if (teams[i].Wins > teams[i + 1].Wins)
                {
                    winers.Add(teams[i]);
                }
                else
                {
                    winers.Add(teams[i + 1]);
                }
            }
            return winers;
        }

        public void InitTeams()
        {
            Teams.Add(new Team("Лига", 5, 10, new List<Player>()
            {
                new Player("Алексей", 2, Player.PlayerStatus.Участник),
                new Player("Серж", 2,Player.PlayerStatus.Глава),
                new Player("Жека", 2, Player.PlayerStatus.Соруководитель),
                new Player("Александр", 2, Player.PlayerStatus.Старейшина),
                new Player("Антон", 2, Player.PlayerStatus.Соруководитель ),
            }));
            Teams.Add(new Team("Ужас", 15, 12, new List<Player>()
            {
                new Player("Макс", 2, Player.PlayerStatus.Участник),
                new Player("Ден", 3,Player.PlayerStatus.Глава),
                new Player("Иван", 3, Player.PlayerStatus.Соруководитель),
                new Player("Андрей", 2, Player.PlayerStatus.Старейшина),
                new Player("Никита", 2, Player.PlayerStatus.Соруководитель ),
            }));
            Teams.Add(new Team("HULK", 15, 12, new List<Player>()
            {
                new Player("Станислав", 2, Player.PlayerStatus.Участник),
                new Player("Слава", 3,Player.PlayerStatus.Глава),
                new Player("Степан", 3, Player.PlayerStatus.Соруководитель),
                new Player("Серёга", 2, Player.PlayerStatus.Старейшина),
                new Player("Саня", 2, Player.PlayerStatus.Соруководитель ),
            }));
            Teams.Add(new Team("RAB", 15, 12, new List<Player>()
            {
                new Player("Игорь", 2, Player.PlayerStatus.Участник),
                new Player("Вовка", 3,Player.PlayerStatus.Глава),
                new Player("Олег", 3, Player.PlayerStatus.Соруководитель),
                new Player("Максим", 2, Player.PlayerStatus.Старейшина),
                new Player("Юра", 2, Player.PlayerStatus.Соруководитель ),
            }));
            Teams.Add(new Team("Red", 5, 10, new List<Player>()
            {
                new Player("Матвей", 2, Player.PlayerStatus.Участник),
                new Player("Виктор", 2,Player.PlayerStatus.Глава),
                new Player("Витя", 2, Player.PlayerStatus.Соруководитель),
                new Player("Стас", 2, Player.PlayerStatus.Старейшина),
                new Player("Антоха", 2, Player.PlayerStatus.Соруководитель ),
            }));
            Teams.Add(new Team("King", 15, 12, new List<Player>()
            {
                new Player("Сеня", 2, Player.PlayerStatus.Участник),
                new Player("Димка", 3,Player.PlayerStatus.Глава),
                new Player("Добрыня", 3, Player.PlayerStatus.Соруководитель),
                new Player("Миша", 2, Player.PlayerStatus.Старейшина),
                new Player("Костя", 2, Player.PlayerStatus.Соруководитель ),
            }));
            Teams.Add(new Team("Дикие", 15, 12, new List<Player>()
            {
                new Player("Вика", 2, Player.PlayerStatus.Участник),
                new Player("Марина", 3,Player.PlayerStatus.Глава),
                new Player("Настя", 3, Player.PlayerStatus.Соруководитель),
                new Player("Лена", 2, Player.PlayerStatus.Старейшина),
                new Player("Олеся", 2, Player.PlayerStatus.Соруководитель ),
            }));
            Teams.Add(new Team("Зубзазуб", 15, 12, new List<Player>()
            {
                new Player("Соня", 2, Player.PlayerStatus.Участник),
                new Player("Валера", 3,Player.PlayerStatus.Глава),
                new Player("Оля", 3, Player.PlayerStatus.Соруководитель),
                new Player("Елисей", 2, Player.PlayerStatus.Старейшина),
                new Player("Таня", 2, Player.PlayerStatus.Соруководитель ),
            }));
        }
    }
}
