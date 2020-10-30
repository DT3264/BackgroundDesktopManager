using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
namespace BackgroundDesktopManager
{
    public class Utils
    {
        private string[] files;
        private int nextImageIdx;
        private IActiveDesktop iad;
        public Settings settings { get; set; }
        public Utils(Settings settings)
        {
            this.settings = settings;
            iad = shlobj.GetActiveDesktop();
            files = getImagesInPath();
            nextImageIdx = getIndexOfLastOrNear();
            setNextImage();
        }
        private void setImage(string path)
        {
            iad.SetWallpaper(path, 0);
            iad.ApplyChanges(AD_Apply.SAVE | AD_Apply.HTMLGEN | AD_Apply.REFRESH | AD_Apply.FORCE | AD_Apply.BUFFERED_REFRESH);
        }
        public void setNextImage()
        {

            nextImageIdx++;
            if (nextImageIdx >= files.Length)
            {
                nextImageIdx = 0;
            }

            setImage(files[nextImageIdx]);
            settings.lastFile = files[nextImageIdx];

            settings.lastFile = settings.lastFile;
            settings.writeLastFile();
        }

        public void setPreviousImage()
        {
            nextImageIdx--;
            if (nextImageIdx < 0)
            {
                nextImageIdx = files.Length-1;
            }

            setImage(files[nextImageIdx]);
            settings.lastFile = files[nextImageIdx];

            settings.lastFile = settings.lastFile;
            settings.writeLastFile();
            
        }

        private string[] getImagesInPath()
        {
            List<string> list = new List<string>();
            foreach (string picture in Directory.GetFiles(settings.folderPath, "*.*", SearchOption.AllDirectories))
            {
                if (picture.Contains("ignore")) continue;
                if (Regex.IsMatch(picture, ".jpg|.jpeg|.png|.gif|.tiff|.bmp|.svg$"))
                {
                    list.Add(picture);
                }
            }
            return list.ToArray();
        }
        private int getIndexOfLastOrNear()
        {
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].CompareTo(settings.lastFile) >= 0)
                {
                    return i-1;
                }
            }
            return -1;
        }
    }
}
