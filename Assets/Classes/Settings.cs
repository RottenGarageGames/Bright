using Newtonsoft.Json;

namespace Classes
{
    public class Settings
    {
        private const string _settingsFileName = "Settings.json";

        public enum GameDifficulty { Easy, Medium, Hard }

        public bool AutoSave { get; set; } = true;
        public int AutoSaveInterval { get; set; } = 5;//= 30;
        public int MusicVolume { get; set; } = 100;
        public int MasterVolume { get; set; } = 100;
        public int XSensitivity { get; set; } = 3;
        public int YSensitivity { get; set; } = 3;
        public GameDifficulty Difficulty { get; set; } = GameDifficulty.Easy;

        public Settings()
        {
            Load();
        }

        public void Save()
        {
            var settingsString = JsonConvert.SerializeObject(this);

            Globals.SaveGameFile(_settingsFileName, settingsString);
        }

        public void Load()
        {
            var settingsString = Globals.ReadGameFileText(_settingsFileName);

            if (!settingsString.IsNullOrWhiteSpace())
            {
                this.CopyFrom(JsonConvert.DeserializeObject<Settings>(settingsString));
            }
        }
    }
}
