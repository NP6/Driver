using Newtonsoft.Json;

namespace NP6Api.Models
{
    public class TestModel
    {
        [JsonProperty("fortest")]
        public bool? Fortest { get; set; }

        [JsonProperty("campaignAnalyser", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CampaignAnalyser { get; set; }

        [JsonProperty("testSegments")]
        public int[] TestSegments { get; set; }

        [JsonProperty("mediaForTest", NullValueHandling = NullValueHandling.Ignore)]
        public string MediaForTest { get; set; }

        [JsonProperty("textandHtml", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TextandHtml { get; set; }

        [JsonProperty("comments", NullValueHandling = NullValueHandling.Ignore)]
        public string Comments { get; set; }
    }
}
