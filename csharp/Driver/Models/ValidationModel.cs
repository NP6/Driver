using Newtonsoft.Json;

namespace NP6Api.Models
{
    public class ValidationModel
    {
        [JsonProperty("fortest", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Fortest { get; set; }

        [JsonProperty("campaignAnalyser", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CampaignAnalyser { get; set; }

        [JsonProperty("testSegments", NullValueHandling = NullValueHandling.Ignore)]
        public int[] TestSegments { get; set; }

        [JsonProperty("mediaForTest", NullValueHandling = NullValueHandling.Ignore)]
        public string MediaForTest { get; set; }

        [JsonProperty("textandHtml", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TextandHtml { get; set; }

        [JsonProperty("comments", NullValueHandling = NullValueHandling.Ignore)]
        public string Comments { get; set; }
    }
}
