using ds.enovia.common;
using System.Collections.Generic;

namespace ds.enovia.dslc.model
{
    public class Unreserve : SerializableJsonObject
    {

        public Unreserve(IList<IPhysicalId> data)
        {
            this.data = data;
        }

        public IList<IPhysicalId> data { get; set; }
    }
}
