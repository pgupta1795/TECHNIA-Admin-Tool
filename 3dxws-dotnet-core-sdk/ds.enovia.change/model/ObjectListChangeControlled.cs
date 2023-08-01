using ds.enovia.common;

namespace ds.enovia.change
{
    public class ObjectListChangeControlled : SerializableJsonObject
    {
        public required string id { get; set; }

        public required string changeControlValue { get; set; }

        public required string type { get; set; }
    }
}
