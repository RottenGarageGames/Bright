using System.IO;
using UnityEngine;

namespace Classes
{
    public static class Globals
    {
        public static string GameFilePath
        {
            get
            {
                return $"{Application.persistentDataPath.Replace('/', '\\')}\\";
            }
        }

        public static void SaveGameFile(string fileName, string contents)
        {
            File.WriteAllText(GameFilePath + fileName, contents);
        }

        public static string ReadGameFileText(string fileName)
        {
            var filePath = GameFilePath + fileName;

            if (!File.Exists(filePath))
            {
                return null;
            }

            return File.ReadAllText(filePath);
        }
    }
}
