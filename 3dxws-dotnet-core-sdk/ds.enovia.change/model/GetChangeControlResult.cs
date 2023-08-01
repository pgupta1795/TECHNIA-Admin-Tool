using System.Text.Json.Serialization;

namespace ds.enovia.change
{
    public class GetChangeControlResult
    {
        [JsonPropertyName("totalItems")]
        public long totalItems { get; set; }

        public required List<Members> member { get; set; }
    }
}
