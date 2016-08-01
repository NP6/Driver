using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NP6Api.Models
{
    public class IActionModel
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("information")]
        public Information Informations { get; set; }
    }

    public class Information
    {
        [JsonProperty("folder")]
        public string Folder { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }
    }
    public class Scheduler
    {
        [JsonProperty("segments")]
        public Segment Segments { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Segment
    {
        [JsonProperty("selected")]
        public int[] Selected { get; set; }
    }

    public class Content
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("html")]
        public string Html { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("headers")]
        public Header Headers { get; set; }
    }

    public class Header
    {
        [JsonProperty("from")]
        public From From { get; set; }

        [JsonProperty("reply")]
        public string Reply { get; set; }
    }

    public class From
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("prefix")]
        public string Prefix { get; set; }
    }

    public class SMSContent
    {
        [JsonProperty("textContent")]
        public string TextContent { get; set; }
    }
}
