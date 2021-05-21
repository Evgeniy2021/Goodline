using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinForms_eSport
{
    class Program
    {
        static public List<Team> Teams = new List<Team>();
        static void InitTeams()
        {
            Program.Teams.Add(new Team("����", 5, 10, new List<Player>()
            {
                new Player("�������", 2, Player.PlayerStatus.��������),
                new Player("����", 2,Player.PlayerStatus.�����),
                new Player("����", 2, Player.PlayerStatus.��������������),
                new Player("���������", 2, Player.PlayerStatus.����������),
                new Player("�����", 2, Player.PlayerStatus.�������������� ),
            }));
            Program.Teams.Add(new Team("����", 15, 12, new List<Player>()
            {
                new Player("����", 2, Player.PlayerStatus.��������),
                new Player("���", 3,Player.PlayerStatus.�����),
                new Player("����", 3, Player.PlayerStatus.��������������),
                new Player("������", 2, Player.PlayerStatus.����������),
                new Player("������", 2, Player.PlayerStatus.�������������� ),
            }));
            Program.Teams.Add(new Team("HULK", 15, 12, new List<Player>()
            {
                new Player("���������", 2, Player.PlayerStatus.��������),
                new Player("�����", 3,Player.PlayerStatus.�����),
                new Player("������", 3, Player.PlayerStatus.��������������),
                new Player("�����", 2, Player.PlayerStatus.����������),
                new Player("����", 2, Player.PlayerStatus.�������������� ),
            }));
            Program.Teams.Add(new Team("RAB", 15, 12, new List<Player>()
            {
                new Player("�����", 2, Player.PlayerStatus.��������),
                new Player("�����", 3,Player.PlayerStatus.�����),
                new Player("����", 3, Player.PlayerStatus.��������������),
                new Player("������", 2, Player.PlayerStatus.����������),
                new Player("���", 2, Player.PlayerStatus.�������������� ),
            }));
            Program.Teams.Add(new Team("Red", 5, 10, new List<Player>()
            {
                new Player("������", 2, Player.PlayerStatus.��������),
                new Player("������", 2,Player.PlayerStatus.�����),
                new Player("����", 2, Player.PlayerStatus.��������������),
                new Player("����", 2, Player.PlayerStatus.����������),
                new Player("������", 2, Player.PlayerStatus.�������������� ),
            }));
            Program.Teams.Add(new Team("King", 15, 12, new List<Player>()
            {
                new Player("����", 2, Player.PlayerStatus.��������),
                new Player("�����", 3,Player.PlayerStatus.�����),
                new Player("�������", 3, Player.PlayerStatus.��������������),
                new Player("����", 2, Player.PlayerStatus.����������),
                new Player("�����", 2, Player.PlayerStatus.�������������� ),
            }));
            Program.Teams.Add(new Team("�����", 15, 12, new List<Player>()
            {
                new Player("����", 2, Player.PlayerStatus.��������),
                new Player("������", 3,Player.PlayerStatus.�����),
                new Player("�����", 3, Player.PlayerStatus.��������������),
                new Player("����", 2, Player.PlayerStatus.����������),
                new Player("�����", 2, Player.PlayerStatus.�������������� ),
            }));
            Program.Teams.Add(new Team("��������", 15, 12, new List<Player>()
            {
                new Player("����", 2, Player.PlayerStatus.��������),
                new Player("������", 3,Player.PlayerStatus.�����),
                new Player("���", 3, Player.PlayerStatus.��������������),
                new Player("������", 2, Player.PlayerStatus.����������),
                new Player("����", 2, Player.PlayerStatus.�������������� ),
            }));
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InitTeams();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
           // Application.Run(new Form1());

        }
    }
}
