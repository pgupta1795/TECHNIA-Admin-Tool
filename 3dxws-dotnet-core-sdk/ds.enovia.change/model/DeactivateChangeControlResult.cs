using ds.enovia.common;
using System.Text.Json.Serialization;

namespace ds.enovia.change
{
    public class DeactivateChangeControlResult : SerializableJsonObject
    {
        [JsonPropertyName("version")]
        public required string version { get; set; }

        [JsonPropertyName("objectListChangeControlled")]
        public required List<ObjectListChangeControlled> objectListChangeControlled { get; set; }
    }
}
