using System.Dynamic;

namespace technia.admintool.settings
{
    public static class ExpandoObjectUtils
    {
        public static IDictionary<string, object> GetDictionary(ExpandoObject record)
        {
            return (IDictionary<string, object>)record;
        }

        public static string[] GetAllKeys(List<ExpandoObject> records)
        {
            if (records.Count < 1) return Array.Empty<string>();
            var record = GetDictionary(records[0]);
            var keys = record.Keys.ToArray();
            return keys;
        }

        public static List<string[]> GetAllValues(List<ExpandoObject> records)
        {
            List<string[]> rows = new();
            foreach (var record in records)
            {
                var dict = GetDictionary(record);
                /*List<string> row = new();
                foreach (var key in dict.Keys)
                {
                    var value = dict[key];
                    row.Add(value.ToString());
                }*/
                string[] row = dict.Values.ToArray().Select(element => element.ToString()).ToArray();
                rows.Add(row);
            }
            return rows;
        }
    }
}
