using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KonchuSugoizeNotifyLambda.Resources.Twitter
{
    public class TweetParameter
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("in_reply_to_status_id")]
        public string? InReplyToStatusId { get; set; }
    }
}
