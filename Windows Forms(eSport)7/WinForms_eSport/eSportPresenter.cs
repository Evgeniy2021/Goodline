using System.Windows.Forms;
using System.Collections.Generic;

namespace WinForms_eSport
{
    public class eSportPresenter
    {
        public Form1 View;
        public eSportModel Model;
        public eSportPresenter(Form1 view, eSportModel model)
        {
            Model = model;
            View = view;
        }
        public string GetTeamsInfo()
        {
            return Model.GetTeamsInfo();
        }

        public void Tournament(List<TextBox> tour1, List<TextBox> tour2, List<TextBox> tour3, TextBox textBox21)
        {
            if (Model.Teams.Count == 8) {
                List<Team> teams = Model.Teams;
                Model.TournamentSetWins(teams);
                for (int i = 0; i < tour1.Count; i++)
                {
                    tour1[i].Text = teams[i].TeamName + " (" + teams[i].Wins + ")";
                }
                teams = Model.TournamentGetWinTeams(teams);
                Model.TournamentSetWins(teams);
                for (int i = 0; i < tour2.Count; i++)
                {
                    tour2[i].Text = teams[i].TeamName + " (" + teams[i].Wins + ")";
                }
                teams = Model.TournamentGetWinTeams(teams);
                Model.TournamentSetWins(teams);
                for (int i = 0; i < tour3.Count; i++)
                {
                    tour3[i].Text = teams[i].TeamName + " (" + teams[i].Wins + ")";
                }
                teams = Model.TournamentGetWinTeams(teams);
                textBox21.Text = teams[0].TeamName + " (" + teams[0].Wins + ")";
            }
            else
            {
                MessageBox.Show("Неверное кол-во команд! Должно быть 8!");
            }
        }
    }
}
