namespace eSport
{
    class TeamPlayer
    {
        public string Name { get; set; }
        public string ClanName { get; set; }
        public int OfWins { get; set; }
        public int Level { get; set; }
        public enum Status
        {
            Глава,
            Соруководитель,
            Старейшина,
            Участник
        }
    }
}

