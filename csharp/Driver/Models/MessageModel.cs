using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP6Api.Models
{
    public class MessageModel
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("content")]
        public MessageContent Content { get; set; }

        [JsonProperty("header")]
        public MessageHeader Header { get; set; }
    }

    public class MessageContent
    {
        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class MessageHeader
    {
        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("mailFrom")]
        public string MailFrom { get; set; }

        [JsonProperty("replyTo")]
        public string ReplyTo { get; set; }
    }
}
