using Newtonsoft.Json;

namespace NP6Api.Models
{
    public class SegmentModel
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("isTest")]
        public bool IsTest { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("expiration")]
        public string Expiration { get; set; }
    }
}
