using Classes;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Settings Settings { get; set; } = new Settings();

    public PlayerController Player;

    public Timer AutoSaveTimer;

    public GameManager()
    {
        SetupAutoSaveTimer();

        Load();
    }

    public void SaveGameState(int? slot = null)
    {
        var saveStateData = new SaveStateData(Player);

        var stringData = JsonConvert.SerializeObject(saveStateData);

        string fileName = slot.HasValue ? $"Slot{slot.Value}_{DateTime.Now.ToShortDateString()}".Replace('/', '.').Replace(' ', '_').Replace(':', '.') + ".json" : "AutoSave.json";

        if (slot.HasValue)
        {
            DeleteGameStateFile(slot.Value);
        }

        Globals.SaveGameFile(fileName, stringData);
    }

    public void DeleteGameStateFile(int slot)
    {
        var directory = new DirectoryInfo(Application.persistentDataPath);

        var file = directory.GetFiles().SingleOrDefault(x => x.Name.StartsWith($"Slot{slot}"));

        if(file != null)
        {
            file.Delete();
        }
    }

    public void Load(int slot)
    {
        var directory = new DirectoryInfo(Application.persistentDataPath);
        var save = directory.GetFiles().SingleOrDefault(x => x.Name.StartsWith($"Slot{slot}"));

        if (save != null)
        {
            var json = File.ReadAllText(save.FullName);

            var data = JsonConvert.DeserializeObject<SaveStateData>(json);

            UpdateByGameData(data);
        }
        else
        {
            throw new Exception($"No save file found for slot {slot}.");
        }
    }

    public void Load()
    {
        var directory = new DirectoryInfo(Application.persistentDataPath);
        var lastSave = directory.GetFiles().OrderByDescending(x => x.LastWriteTime).FirstOrDefault();

        //Last save is being loaded if you do a build of the game on your computer
        //I'm setting it to null to test. Shouldn't be an issue when there are actual save files to load.
        lastSave = null;

        if (lastSave != null)
        {
            var json = File.ReadAllText(lastSave.FullName);

            var data = JsonConvert.DeserializeObject<SaveStateData>(json);

            UpdateByGameData(data);
        }
    }

    public void SetupAutoSaveTimer()
    {
        TimerCallback callback = (object state) =>
        {
            SaveGameState();
        };

        AutoSaveTimer = new Timer(callback);

        AutoSaveTimer.Change(TimeSpan.FromMinutes(Settings.AutoSaveInterval), TimeSpan.FromMinutes(Settings.AutoSaveInterval));
    }

    public void UpdateByGameData(SaveStateData saveStateData)
    {
        Player = saveStateData.Player;
    }
}
