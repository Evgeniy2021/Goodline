namespace eSport
{
    class Player
    {
        public string Name { get; set; }
        //public string ClanName { get; set; }
        public int OfWins { get; set; }
        public int Level { get; set; }
        public enum PlayerStatus
        {
            Глава,
            Соруководитель,
            Старейшина,
            Участник
        }
        public PlayerStatus Status { get; set; }

    }
}

