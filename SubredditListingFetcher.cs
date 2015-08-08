using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedditSharp;
using RedditSharp.Things;
using System.Collections;
using System.Net;

namespace RedditWallpapers
{
    public class SubredditListingFetcher
    {
        private static int pageSize = 25;
        static string username = "dabblebot0123456";
        static string password = "oin345897j2@1";
        Reddit reddit;
    
        public SubredditListingFetcher()
        {
            reddit = new Reddit(username, password);
        }

        private ArrayList searchTitles(Listing<Post> listing, string keyword, int maxPostsToSearch)
        {
            ArrayList retList = new ArrayList();
            foreach (Post post in listing.Take<Post>(maxPostsToSearch))
            {
                if (post.Title.ToLower().Contains(keyword.ToLower()))
                {
                    retList.Add(post);
                }
            }
            return retList;
        }

        public ArrayList getTopByKeyword (string subName, int maxPostsToSearch, FromTime time, string keyword)
        {
            Subreddit sub = reddit.GetSubreddit(subName);
            Listing<Post> top = sub.GetTop(time);
            return searchTitles(top, keyword, maxPostsToSearch);
        }

        public ArrayList getHotByKeyword(string subName, int maxPostsToSearch, string keyword)
        {
            Subreddit sub = reddit.GetSubreddit(subName);
            Listing<Post> listing = sub.Hot;         
            return searchTitles(listing, keyword, maxPostsToSearch);
        }
    }
}
