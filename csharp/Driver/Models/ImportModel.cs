using Newtonsoft.Json;

namespace NP6Api.Models
{
    public class ImportModel
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("features", NullValueHandling = NullValueHandling.Ignore)]
        public Feature[] Features { get; set; }

        [JsonProperty("binding")]
        public int Binding { get; set; }
    }

    public class Feature
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("segmentId", NullValueHandling = NullValueHandling.Ignore)]
        public int? SegmentId { get; set; }

        [JsonProperty("emptyExisitingSegment", NullValueHandling = NullValueHandling.Ignore)]
        public bool? EmptyExistingSegment { get; set; }
        
        [JsonProperty("rules", NullValueHandling = NullValueHandling.Ignore)]
        public Rule Rules { get; set; }

        [JsonProperty("sendFinalReport", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SendFinalReport { get; set; }

        [JsonProperty("sendErrorReport", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SendErrorReport { get; set; }

        [JsonProperty("contactGuids")]
        public string[] ContactGuids { get; set; }

        [JsonProperty("groupIds")]
        public int[] GroupIds { get; set; }

        [JsonProperty("updateExisting", NullValueHandling = NullValueHandling.Ignore)]
        public bool? UpdateExisting { get; set; }

        [JsonProperty("crushData", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CrushData { get; set; }
    }

    public class Rule
    {
        [JsonProperty("ignore")]
        public bool Ignore { get; set; }
    }
}
