# BackgroundDesktopManager
Set wallpapers inside a folder and it's subfolders

```
> backgroundManager.exe <path> <seconds>
```
Where <path> is a path to a folder and <seconds> the interval of each wallpaper

Notes: 
- If an image has "ignore" in the name or extension, it would be ignored
- The format of pictures that it uses, given the regex, are [.jpg|.jpeg|.png|.gif|.tiff|.bmp|.svg]
- If the pictures don't fade, go to Configuration/Personalization, choose "Presentation" and to reload the wallpaper, right click on the tray icon, go 1 back and 1 next
- It resumes from the last image or the nearest if the last doesn't exist anymore
