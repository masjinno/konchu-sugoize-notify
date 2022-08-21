using CoreTweet;
using KonchuSugoizeNotifyLambda.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KonchuSugoizeNotifyLambda.Models
{
    public class TwitterCaller
    {
        private Tokens token;

        public TwitterCaller(TwitterConfig conf)
        {
            this.token = Tokens.Create(conf.ConsumerKey, conf.ConsumerSecret, conf.AccessToken, conf.AccessSecret);
        }

        public void PostTweet(List<string> tweetBody)
        {
            Status? status = null;
            tweetBody.ForEach(body =>
            {
                long inRepryToStatusId;
                if (status != null)
                {
                    //body = "@" + status.User.Id + " " + body;
                    inRepryToStatusId = status.Id;
                }
                else
                {
                    inRepryToStatusId = 0;
                }
                status = token.Statuses.Update(new { status = body, in_repry_to_status_id = inRepryToStatusId });
            });
        }
    }
}
