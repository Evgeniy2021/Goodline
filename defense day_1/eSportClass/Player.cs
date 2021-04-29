namespace eSport

{
    public class Player
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public enum PlayerStatus
        {
            Глава,
            Соруководитель,
            Старейшина,
            Участник,
            Не_определён
        }
        public PlayerStatus Status { get; set; }
        public Player()
        {
            Name = "Нет имени";
            this.Level = 0;
            this.Status = (PlayerStatus)4;
        }
        public Player(string Name, int Level, PlayerStatus Status)
        {
            this.Name = Name;
            this.Level = Level;
            this.Status = Status;
        }
        public override string ToString()
        {
            return $"{Name,-10} Звёзд:{Level,-3} {Status,-3}";
        }
    }
}

