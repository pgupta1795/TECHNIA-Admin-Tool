using System.Text.Json.Serialization;

namespace ds.enovia.dslc.model
{
    public class UnreservePayload
    {
        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonPropertyName("reserved")]
        public bool reserved { get; set; }

        [JsonPropertyName("reservedBy")]
        public string reservedBy { get; set; }
    }
}
