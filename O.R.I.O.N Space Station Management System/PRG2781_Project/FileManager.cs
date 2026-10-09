using System;
using System.IO;

namespace PRG2781_Project
{
    internal class FileManager
    {
        public void Save(string text)
        {
            File.WriteAllText("StationData.txt", text);
        }

        public string Load()
        {
            if (File.Exists("StationData.txt"))
            {
                return File.ReadAllText("StationData.txt");
            }

            return "No saved data found.";
        }
    }
}