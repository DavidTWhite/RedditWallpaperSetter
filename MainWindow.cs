using RedditSharp.Things;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedditWallpapers
{
    public partial class MainWindow : Form
    {
        SubredditListingFetcher subFetcher = new SubredditListingFetcher();
        WallpaperManager wpManager = new WallpaperManager();
        ImgurTools imgurHelper = new ImgurTools();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void getResults_buttonclick(object sender, EventArgs e)
        {
            string subreddit = this.subChooserCombo.Text;
            string listing = this.listingTypeCombo.Text.ToLower();
            string keyword = this.searchTermInput.Text;
            if (string.IsNullOrWhiteSpace(subreddit))
            {
                MessageBox.Show("Please select a subreddit");
                return;
            }
            else if (string.IsNullOrWhiteSpace(keyword))
            {
                MessageBox.Show("Please enter a search term");
                return;
            }
            ArrayList results;
            if (listing == "top")
            {
                results = subFetcher.getTopByKeyword(subreddit, 100, FromTime.Month, keyword);
            }
            else if ( listing == "hot")
            {
                results = subFetcher.getHotByKeyword(subreddit, 100, keyword);
            }
            else
            {
                return;
            }
            ArrayList urlList = new ArrayList();
            foreach (Post post in results)
            {
                if (post.Url.OriginalString.Contains("imgur"))
                {
                    this.resultsList.Items.Add(post.Title);
                    urlList.Add(post.Url);
                }
            }
            this.resultsList.LargeImageList = imgurHelper.getThumbnails(urlList);
            int imageIndex = 0;
            foreach (var result in resultsList.Items)
            {
                resultsList.Items[imageIndex].ImageIndex = imageIndex;
                resultsList.Items[imageIndex].Tag = urlList[imageIndex];
                imageIndex++;
            }
            //call get objects, turn that collection in ListviewItems 
        }

        private void setWallpaperButton_Click(object sender, EventArgs e)
        {
            string url = (string)resultsList.SelectedItems[0].Tag.ToString();
            string filename = imgurHelper.getFullImage(url, url.Split('/').Last());
            wpManager.setWallpaper(filename);
        }
    }
}
