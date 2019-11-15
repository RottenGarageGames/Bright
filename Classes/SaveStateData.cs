namespace Classes
{
    public class SaveStateData
    {
        public PlayerController Player { get; set; }

        public SaveStateData(PlayerController player)
        {
            Player = player;
        }
    }
}
