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
            return File.ReadAllText(GameFilePath + fileName);
        }
    }
}
