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

    public class ImgurTools
    {
        WebClient webClient;
        string tempPath;
        string picsPath;
        public ImgurTools()
        {
            this.webClient = new WebClient();
            string sysTempPath = Path.GetTempPath();
            tempPath = Path.Combine(sysTempPath, "redditWallpaperIcons");
            picsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        }

        public ImageList getThumbnails(ArrayList postURLs)
        {
            if (!Directory.Exists(tempPath))
            {
                Directory.CreateDirectory(tempPath);
            }
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(90, 90);
            imageList.ColorDepth = ColorDepth.Depth24Bit;
            foreach (Uri uri in postURLs)
            {
                string ext = Path.GetExtension(uri.LocalPath);
                string address = uri.AbsoluteUri.Substring(0, uri.AbsoluteUri.LastIndexOf(".")) + "s" + ext;
                if (ext == "")
                {
                    // some URLs don't point directly to the image, so appending a dummy extension
                    ext = ".png";
                    address = uri.AbsoluteUri + "s" + ext;
                }

                string filename = Path.Combine(tempPath, Path.GetFileNameWithoutExtension(uri.LocalPath) + "_thumb" + ext);
                webClient.DownloadFile(address, filename);
                imageList.Images.Add(Image.FromFile(filename));
            }
            return imageList; 
        }

        ~ImgurTools()
        {
            try
            {
                Directory.Delete(tempPath, true);
            }
            catch { } //don't care
        }

        internal string getFullImage(string url, string localFilename)
        {
            string fullOutPath = Path.Combine(picsPath, localFilename);
            if (!url.StartsWith("http://i."))
            {
                url = url.Replace("http://", "http://i.");
                if (!url.EndsWith(".png") || !url.EndsWith(".jpg"))
                {
                    //TODO: Implement Imgur API for pulling these images correctly
                    url = url + ".png";
                    fullOutPath += ".png";
                }
            }
            webClient.DownloadFile(url, fullOutPath);
            return fullOutPath;
        }
    }
}
