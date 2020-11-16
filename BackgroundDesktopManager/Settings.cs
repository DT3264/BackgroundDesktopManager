using System;
using System.Collections.Generic;
using System.IO;
namespace BackgroundDesktopManager
{
    public class Settings
    {
        public List<string> folders { get; set; }
        public string lastFile { get; set; }
        public int interval { get; set; }
        public Settings(string[] args)
        {
            folders = new List<string>();
            for(int i=0; i<args.Length; i++)
            {
                if(args[i].Equals("-f")) folders.Add(args[i+1]);
                if(args[i].Equals("-t")) interval = int.Parse(args[i+1]) * 1000;
            }
            if (!File.Exists("lastFile.txt")) File.Create("lastFile.txt").Close();
            lastFile = File.ReadAllText("lastFile.txt");
        }
        public void writeLastFile()
        {
            File.WriteAllText("lastFile.txt", lastFile);
        }
    }
}
