using ds.enovia.common;
using System.Text.Json.Serialization;

namespace ds.enovia.change
{
    public class Members : SerializableJsonObject
    {
        [JsonPropertyName("Change Control Status")]
        public required string changeControlStatus { get; set; }
    }
}
