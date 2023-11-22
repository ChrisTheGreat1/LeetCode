using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class _0355_DesignTwitter
    {
        /*
        Design a simplified version of Twitter where users can post tweets, follow/unfollow another user, 
        and is able to see the 10 most recent tweets in the user's news feed.

        Implement the Twitter class:

        Twitter():
        Initializes your twitter object.

        void postTweet(int userId, int tweetId): 
        Composes a new tweet with ID tweetId by the user userId. 
        Each call to this function will be made with a unique tweetId.
        
        List<Integer> getNewsFeed(int userId):
        Retrieves the 10 most recent tweet IDs in the user's news feed. 
        Each item in the news feed must be posted by users who the user followed or by the user themself. 
        Tweets must be ordered from most recent to least recent.
        
        void follow(int followerId, int followeeId):
        The user with ID followerId started following the user with ID followeeId.
        
        void unfollow(int followerId, int followeeId):
        The user with ID followerId started unfollowing the user with ID followeeId.



        Input
        ["Twitter", "postTweet", "getNewsFeed", "follow", "postTweet", "getNewsFeed", "unfollow", "getNewsFeed"]
        [[], [1, 5], [1], [1, 2], [2, 6], [1], [1, 2], [1]]
        Output
        [null, null, [5], null, null, [6, 5], null, [5]]

        Explanation
        Twitter twitter = new Twitter();
        twitter.postTweet(1, 5); // User 1 posts a new tweet (id = 5).
        twitter.getNewsFeed(1);  // User 1's news feed should return a list with 1 tweet id -> [5]. return [5]
        twitter.follow(1, 2);    // User 1 follows user 2.
        twitter.postTweet(2, 6); // User 2 posts a new tweet (id = 6).
        twitter.getNewsFeed(1);  // User 1's news feed should return a list with 2 tweet ids -> [6, 5]. Tweet id 6 should precede tweet id 5 because it is posted after tweet id 5.
        twitter.unfollow(1, 2);  // User 1 unfollows user 2.
        twitter.getNewsFeed(1);  // User 1's news feed should return a list with 1 tweet id -> [5], since user 1 is no longer following user 2.
 

        Constraints:

        1 <= userId, followerId, followeeId <= 500
        0 <= tweetId <= 10^4
        All the tweets have unique IDs.
        At most 3 * 10^4 calls will be made to postTweet, getNewsFeed, follow, and unfollow.

        */

        /**
         * Your Twitter object will be instantiated and called as such:
         * Twitter obj = new Twitter();
         * obj.PostTweet(userId,tweetId);
         * IList<int> param_2 = obj.GetNewsFeed(userId);
         * obj.Follow(followerId,followeeId);
         * obj.Unfollow(followerId,followeeId);
         */

        public class Twitter
        {

            private PriorityQueue<TweetInfo, int> pq;
            private int time;
            private Dictionary<int, HashSet<int>> followers;
            private Dictionary<int, List<Tweet>> tweets;

            public Twitter()
            {
                time = 0;
                pq = new PriorityQueue<TweetInfo, int>(new MaxHeap());
                followers = new Dictionary<int, HashSet<int>>();
                tweets = new Dictionary<int, List<Tweet>>();
            }

            //T: O(1)
            public void PostTweet(int userId, int tweetId)
            {
                time++;
                if (!tweets.ContainsKey(userId))
                    tweets.Add(userId, new List<Tweet>());
                tweets[userId].Add(new Tweet(time, tweetId));
            }

            public IList<int> GetNewsFeed(int userId)
            {
                var result = new List<int>();
                var followersOfUserId = new HashSet<int>();
                if (followers.ContainsKey(userId))
                    followersOfUserId = followers[userId];
                followersOfUserId.Add(userId);

                //We are just adding the last indexed tweet of the all the followers tweet
                foreach (var followeeId in followersOfUserId)
                {
                    if (tweets.ContainsKey(followeeId))
                    {
                        var lastTweetIndex = tweets[followeeId].Count - 1;
                        var tweet = tweets[followeeId][lastTweetIndex];
                        var tweetInfo = new TweetInfo(tweet.Time, tweet.TweetId, followeeId, lastTweetIndex - 1);
                        pq.Enqueue(tweetInfo, tweet.Time);
                    }
                }

                while (pq.Count > 0 && result.Count < 10)
                {
                    var tweetInfo = pq.Dequeue();
                    result.Add(tweetInfo.TweetId);

                    if (tweetInfo.Index >= 0)
                    {
                        var tweet = tweets[tweetInfo.FolloweeId][tweetInfo.Index];
                        var tweetInfo2 = new TweetInfo(tweet.Time, tweet.TweetId, tweetInfo.FolloweeId, tweetInfo.Index - 1);
                        pq.Enqueue(tweetInfo2, tweet.Time);
                    }
                }

                return result;
            }

            //T: O(1)
            public void Follow(int followerId, int followeeId)
            {
                if (!followers.ContainsKey(followerId))
                    followers.Add(followerId, new HashSet<int>());
                followers[followerId].Add(followeeId);
            }

            // T: O(1) using HashSet for O(1) deletions
            public void Unfollow(int followerId, int followeeId)
            {
                if (!followers.ContainsKey(followerId))
                    return;
                var followersList = followers[followerId];
                if (followersList.Contains(followeeId))
                    followers[followerId].Remove(followeeId);
            }

            public class Tweet
            {
                public int Time;
                public int TweetId;

                public Tweet(int time, int tweetId)
                {
                    Time = time;
                    TweetId = tweetId;
                }
            }

            public class TweetInfo : Tweet
            {
                public int Index;
                public int FolloweeId;

                public TweetInfo(int time, int tweetId, int followeeId, int index) : base(time, tweetId)
                {
                    Index = index;
                    FolloweeId = followeeId;
                    Time = time;
                    TweetId = tweetId;
                }
            }

            public class MaxHeap : IComparer<int>
            {
                public int Compare(int x, int y)
                {
                    if (x < y) return 1;
                    if (x > y) return -1;
                    else return 0;
                }
            }
        }

        /**
         * Your Twitter object will be instantiated and called as such:
         * Twitter obj = new Twitter();
         * obj.PostTweet(userId,tweetId);
         * IList<int> param_2 = obj.GetNewsFeed(userId);
         * obj.Follow(followerId,followeeId);
         * obj.Unfollow(followerId,followeeId);
         */
    }
}
