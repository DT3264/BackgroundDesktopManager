using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            files = getImagesInDirectories();
            nextImageIdx = getIndexOfLastOrNear();
            setNextImage();
        }
        private void setImage(string path)
        {
            if (!File.Exists(path)) return;
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

        bool isPicture(string path, string[] extensions)
        {
            foreach(var extension in extensions)
            {
                if (path.EndsWith(extension)) return true;
            }
            return false;
        }

        private string[] getImagesInDirectory(string path)
        {
            var extensions = new string[] { ".jpg", ".jpeg", ".png", ".gif", ".tiff", ".bmp", ".svg" };
            var files = new DirectoryInfo(path)
                .GetFiles("*.*")
                .Where(x => isPicture(x.FullName, extensions))
                .OrderByDescending(x => x.CreationTime)
                .Select(x => x.FullName);
            return files.ToArray();
        }

        private string[] getImagesInDirectories()
        {
            var fullPicturesList = new List<string>();
            settings.folders.ForEach( dir => {
                var innerDirectories = new DirectoryInfo(dir).GetDirectories();
                foreach(var innerDirectory in innerDirectories)
                {
                    fullPicturesList.AddRange(getImagesInDirectory(innerDirectory.FullName));
                }
            });
            fullPicturesList.ForEach(p => Console.WriteLine(p));
            return fullPicturesList.ToArray();
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
