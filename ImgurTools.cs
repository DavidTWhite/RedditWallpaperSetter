using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedditWallpapers
{
    public class ImgurTools
    {
        string imgurAPIBaseURL = "https://api.imgur.com/3/";
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
                try
                {
                    imageList.Images.Add(Image.FromFile(filename));
                }
                catch (OutOfMemoryException e)
                {
                    try
                    {
                        address = uri.AbsoluteUri + "b" + ext;
                        filename = Path.Combine(tempPath, Path.GetFileNameWithoutExtension(uri.LocalPath) + "_thumb" + ext);
                        webClient.DownloadFile(address, filename);
                        imageList.Images.Add(Image.FromFile(filename));
                    }
                    catch (OutOfMemoryException e2)
                    {
                        imageList.Images.Add(RedditWallpaperSetter.Properties.Resources.Broken_icon);
                    }
                }
                      
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

        string getImageType(string imageId)
        {
            string uri = imgurAPIBaseURL + "/image/" + imageId;
            webClient.Headers.Add("Authorization", "Client-ID " + ApiKeys.imgurClientId);
            string retval = webClient.DownloadString(uri);
            dynamic json = System.Web.Helpers.Json.Decode(retval);
            return json.data.type;
        }

        string getImageDirectLink(string imageId)
        {
            string uri = imgurAPIBaseURL + "/image/" + imageId;
            webClient.Headers.Add("Authorization", "Client-ID " + ApiKeys.imgurClientId);
            string retval = webClient.DownloadString(uri);
            dynamic json = System.Web.Helpers.Json.Decode(retval);
            return json.data.link;
        }

        string getImageIdFromUrl(string url)
        {
            string imageid = url.Split('/').Last();
            if (imageid.Contains('.'))
            {
                imageid = imageid.Substring(0, imageid.IndexOf('.'));
            }
            return imageid;
        }

        internal string getFullImage(string url, string localFilename)
        {
            string fullOutPath = Path.Combine(picsPath, localFilename);
            string imageLink = getImageDirectLink(getImageIdFromUrl(url));
            webClient.DownloadFile(url, fullOutPath);
            return fullOutPath;
        }
    }
}
