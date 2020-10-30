using System;
using System.Runtime.InteropServices;
using System.Text;
namespace BackgroundDesktopManager
{
    [Flags]
    public enum AD_Apply
    {
        SAVE = 1,
        HTMLGEN = 2,
        REFRESH = 4,
        ALL = 7,
        FORCE = 8,
        BUFFERED_REFRESH = 16,
        DYNAMICREFRESH = 32
    }
    [Flags]
    public enum AddURL
    {
        SILENT = 1
    }
    [Flags]
    public enum CompItemState
    {
        NORMAL = 1,
        FULLSCREEN = 2,
        SPLIT = 4,
        VALIDSIZESTATEBITS = 7,
        VALIDSTATEBITS = -1073741817
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 8)]
    public struct COMPONENT
    {
        private const int INTERNET_MAX_URL_LENGTH = 2084;
        public static readonly int SizeOf = Marshal.SizeOf(typeof(COMPONENT));
        public int dwSize;
        public int dwID;
        public CompType iComponentType;
        [MarshalAs(UnmanagedType.Bool)]
        public bool fChecked;
        [MarshalAs(UnmanagedType.Bool)]
        public bool fDirty;
        [MarshalAs(UnmanagedType.Bool)]
        public bool fNoScroll;
        public COMPPOS cpPos;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string wszFriendlyName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2084)]
        public string wszSource;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2084)]
        public string wszSubscribedURL;
        public int dwCurItemState;
        public COMPSTATEINFO csiOriginal;
        public COMPSTATEINFO csiRestored;
    }
    [Flags]
    public enum ComponentModify
    {
        TYPE = 1,
        CHECKED = 2,
        DIRTY = 4,
        NOSCROLL = 8,
        POS_LEFT = 16,
        POS_TOP = 32,
        SIZE_WIDTH = 64,
        SIZE_HEIGHT = 128,
        POS_ZINDEX = 256,
        SOURCE = 512,
        FRIENDLYNAME = 1024,
        SUBSCRIBEDURL = 2048,
        ORIGINAL_CSI = 4096,
        RESTORED_CSI = 8192,
        CURITEMSTATE = 16384,
        ALL = 32767
    }
    public struct COMPONENTSOPT
    {
        public static readonly int SizeOf = Marshal.SizeOf(typeof(COMPONENTSOPT));
        public int dwSize;
        [MarshalAs(UnmanagedType.Bool)]
        public bool fEnableComponents;
        [MarshalAs(UnmanagedType.Bool)]
        public bool fActiveDesktop;
    }
    public struct COMPPOS
    {
        public const int COMPONENT_TOP = 1073741823;
        public const int COMPONENT_DEFAULT_LEFT = 65535;
        public const int COMPONENT_DEFAULT_TOP = 65535;
        public static readonly int SizeOf = Marshal.SizeOf(typeof(COMPPOS));
        public int dwSize;
        public int iLeft;
        public int iTop;
        public int dwWidth;
        public int dwHeight;
        public int izIndex;
        [MarshalAs(UnmanagedType.Bool)]
        public bool fCanResize;
        [MarshalAs(UnmanagedType.Bool)]
        public bool fCanResizeX;
        [MarshalAs(UnmanagedType.Bool)]
        public bool fCanResizeY;
        public int iPreferredLeftPercent;
        public int iPreferredTopPercent;
    }
    public struct COMPSTATEINFO
    {
        public static readonly int SizeOf = Marshal.SizeOf(typeof(COMPSTATEINFO));
        public int dwSize;
        public int iLeft;
        public int iTop;
        public int dwWidth;
        public int dwHeight;
        public CompItemState dwItemState;
    }
    public enum CompType
    {
        HTMLDOC,
        PICTURE,
        WEBSITE,
        CONTROL,
        CFHTML
    }
    public enum WallPaperStyle
    {
        WPSTYLE_CENTER,
        WPSTYLE_TILE,
        WPSTYLE_STRETCH,
        WPSTYLE_MAX
    }
    public enum DtiAddUI
    {
        DEFAULT,
        DISPSUBWIZARD,
        POSITIONITEM
    }
    public struct WALLPAPEROPT
    {
        public static readonly int SizeOf = Marshal.SizeOf(typeof(WALLPAPEROPT));
    }
    [Guid("F490EB00-1240-11D1-9888-006097DEACF9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IActiveDesktop
    {
        [PreserveSig]
        int ApplyChanges(AD_Apply dwFlags);
        [PreserveSig]
        int GetWallpaper([MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszWallpaper, int cchWallpaper, int dwReserved);
        [PreserveSig]
        int SetWallpaper([MarshalAs(UnmanagedType.LPWStr)] string pwszWallpaper, int dwReserved);
        [PreserveSig]
        int GetWallpaperOptions(ref WALLPAPEROPT pwpo, int dwReserved);
        [PreserveSig]
        int SetWallpaperOptions(ref WALLPAPEROPT pwpo, int dwReserved);
        [PreserveSig]
        int GetPattern([MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszPattern, int cchPattern, int dwReserved);
        [PreserveSig]
        int SetPattern([MarshalAs(UnmanagedType.LPWStr)] string pwszPattern, int dwReserved);
        [PreserveSig]
        int GetDesktopItemOptions(ref COMPONENTSOPT pco, int dwReserved);
        [PreserveSig]
        int SetDesktopItemOptions(ref COMPONENTSOPT pco, int dwReserved);
        [PreserveSig]
        int AddDesktopItem(ref COMPONENT pcomp, int dwReserved);
        [PreserveSig]
        int AddDesktopItemWithUI(IntPtr hwnd, ref COMPONENT pcomp, DtiAddUI dwFlags);
        [PreserveSig]
        int ModifyDesktopItem(ref COMPONENT pcomp, ComponentModify dwFlags);
        [PreserveSig]
        int RemoveDesktopItem(ref COMPONENT pcomp, int dwReserved);
        [PreserveSig]
        int GetDesktopItemCount(out int lpiCount, int dwReserved);
        [PreserveSig]
        int GetDesktopItem(int nComponent, ref COMPONENT pcomp, int dwReserved);
        [PreserveSig]
        int GetDesktopItemByID(IntPtr dwID, ref COMPONENT pcomp, int dwReserved);
        [PreserveSig]
        int GenerateDesktopItemHtml([MarshalAs(UnmanagedType.LPWStr)] string pwszFileName, ref COMPONENT pcomp, int dwReserved);
        [PreserveSig]
        int AddUrl(IntPtr hwnd, [MarshalAs(UnmanagedType.LPWStr)] string pszSource, ref COMPONENT pcomp, AddURL dwFlags);
        [PreserveSig]
        int GetDesktopItemBySource([MarshalAs(UnmanagedType.LPWStr)] string pwszSource, ref COMPONENT pcomp, int dwReserved);
    }
    public class shlobj
    {
        public static IActiveDesktop GetActiveDesktop()
        {
            return (IActiveDesktop)Activator.CreateInstance(Type.GetTypeFromCLSID(shlobj.CLSID_ActiveDesktop));
        }
        public static readonly Guid CLSID_ActiveDesktop = new Guid("{75048700-EF1F-11D0-9888-006097DEACF9}");
    }
}
