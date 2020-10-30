using System;
using System.IO;
namespace BackgroundDesktopManager
{
    public class Settings
    {
        public string folderPath { get; set; }
        public string lastFile { get; set; }
        public int interval { get; set; }
        public Settings(string[] args)
        {
            if (!File.Exists("lastFile.txt")) File.Create("lastFile.txt");
            folderPath = args[0];
            lastFile = File.ReadAllText("lastFile.txt");
            interval = int.Parse(args[1])*1000;
        }
        public void writeLastFile()
        {
            File.WriteAllText("lastFile.txt", lastFile);
        }
    }
}
