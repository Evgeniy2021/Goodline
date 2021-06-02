using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WinForms_eSport
{
    public static class DBeSport
    {
        public static SqlConnection sqlConnection = new SqlConnection(
                    "Data Source=DESKTOP-868HTJ4;Initial Catalog=DBeSport;Integrated Security=True");
        public static void DatabaseLoad(List<Team> teams)
        {
            string sql = "SELECT TeamName, TotalWins FROM WinsTeams";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            sqlConnection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string TeamName = reader.GetString(0);
                    int TotalWins = reader.GetInt32(1);
                    teams.Where(t => t.TeamName == TeamName).ToList().ForEach(i => i.Wins = TotalWins);
                }
            }
            sqlConnection.Close();
            
        }

    }
}
