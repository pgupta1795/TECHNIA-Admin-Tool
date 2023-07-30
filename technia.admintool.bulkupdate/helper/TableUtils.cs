using System.Data;
using System.Dynamic;
using technia.admintool.settings;

namespace technia.admintool.bulkupdate
{
    public static class TableUtils
    {
        public static readonly string DataPropertyName = "DataPropertyName";
        public static DataTable GetTable(List<ExpandoObject> rows)
        {
            DataTable dataTable = new();
            GetTable(rows, ref dataTable, false);
            return dataTable;
        }

        public static DataTable GetTableWithComments(List<ExpandoObject> rows)
        {
            DataTable dataTable = new();
            DataColumn commentsCol = new("Comments");
            dataTable.Columns.Add(commentsCol);

            GetTable(rows, ref dataTable, true);
            return dataTable;
        }

        private static void GetTable(List<ExpandoObject> rows, ref DataTable dataTable, bool addComments)
        {
            string[] headers = ExpandoObjectUtils.GetAllKeys(rows);

            foreach (string columnHeader in headers)
                AddRow(ref dataTable, columnHeader, columnHeader);

            foreach (var record in rows)
            {
                var dict = ExpandoObjectUtils.GetDictionary(record);
                if (addComments) dataTable.Rows.Add(ArrayImplUtils.AddElementAtFirst(dict.Values.ToArray(), "Comments"));
                else dataTable.Rows.Add(dict.Values.ToArray());
            }
        }

        public static void AddRow(ref DataTable dataTable, string value, string displayValue)
        {
            DataColumn? column = new(value)
            {
                ColumnName = displayValue
            };
            column.ExtendedProperties.Add(DataPropertyName, value);
            dataTable.Columns.Add(column);
        }
    }
}