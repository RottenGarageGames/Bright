using Newtonsoft.Json;

namespace Classes
{
    public class SaveStateData
    {
        [JsonIgnore]
        public PlayerController Player { get; private set; }

        public float[] PlayerPosition { get; private set; }

        public SaveStateData(PlayerController player)
        {
            Player = player;
        }

        public string Serialize()
        {
            var position = Player.transform.position;

            PlayerPosition = new float[] { position.x, position.y, position.z };

            return JsonConvert.SerializeObject(this);
        }
    }
}
