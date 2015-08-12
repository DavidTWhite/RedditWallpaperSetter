using System;
using RedditSharp.Things;
using System.Collections;
using System.Net;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace RedditWallpapers
{
    public class WallpaperManager
    {
        public const int SPI_SETDESKWALLPAPER = 20;
        public const int SPIF_UPDATEINIFILE = 1;
        public const int SPIF_SENDCHANGE = 2;
        public enum WallpaperStyle
        {
            Tile,
            Center,
            Stretch,
            Fit,
            Fill
        };
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        public WallpaperManager()
        {
        }

        internal void setWallpaper(string filename)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            var style = WallpaperStyle.Stretch;
            switch (style)
            {
                case WallpaperStyle.Tile:
                    key.SetValue(@"WallpaperStyle", "0");
                    key.SetValue(@"TileWallpaper", "1");
                    break;
                case WallpaperStyle.Center:
                    key.SetValue(@"WallpaperStyle", "0");
                    key.SetValue(@"TileWallpaper", "0");
                    break;
                case WallpaperStyle.Stretch:
                    key.SetValue(@"WallpaperStyle", "2");
                    key.SetValue(@"TileWallpaper", "0");
                    break;
                case WallpaperStyle.Fit: // (Windows 7 and later)
                    key.SetValue(@"WallpaperStyle", "6");
                    key.SetValue(@"TileWallpaper", "0");
                    break;
                case WallpaperStyle.Fill: // (Windows 7 and later)
                    key.SetValue(@"WallpaperStyle", "10");
                    key.SetValue(@"TileWallpaper", "0");
                    break;
            }

            key.Close();
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, filename, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
        }
    }

   
}
